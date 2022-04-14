using CodeBase.GameData.Coins;
using CodeBase.GameData.Hero;
using CodeBase.GameData.Road;
using CodeBase.Helper;
using CodeBase.HeroModule;
using CodeBase.Services.Coins;
using CodeBase.Services.Effects;
using CodeBase.Services.InputService;
using CodeBase.Services.Map;
using CodeBase.Services.SceneLoaderService;
using CodeBase.Services.Score;
using CodeBase.View;
using UnityEngine;

namespace CodeBase
{
    public class GameBootstrapper : MonoBehaviour
    {
        private CameraFollow _cameraFollow;
        
        private void Awake()
        {
            _cameraFollow = Camera.main.GetComponent<CameraFollow>();
            
            var inputService = RegisterInputService();
            var scoreService = new ScoreService();
            
            var coinsTemplate = Resources.Load<CoinsConfig>(AssetsPath.CoinsConfigPath);
            var coinsFactory = new CoinsFactory(coinsTemplate);
            
            InitializeGameMap(coinsFactory);
            
            var heroConfig = Resources.Load<HeroConfig>(AssetsPath.HeroConfigPath);
            var hero = Instantiate(AssetsPath.HeroPath).GetComponent<Hero>();
            hero.Constructor(inputService, scoreService, heroConfig);

            var effectService = Instantiate(AssetsPath.EffectServicePath).GetComponent<EffectsService>();
            effectService.Constructor(hero);

            var hudView = Instantiate(AssetsPath.HudPath).GetComponent<HudView>();
            hudView.Constructor(hero, scoreService, new SceneLoader());
            
            _cameraFollow.Follow(hero.gameObject);
        }

        private void InitializeGameMap(CoinsFactory coinsFactory)
        {
            Instantiate(AssetsPath.GameMapPath);
            
            var roadConfig = Resources.Load<RoadsConfig>(AssetsPath.RoadsConfigPath);
            
            var roadFactory = new RoadSectionFactory(roadConfig);
            var roadGenerator = Instantiate(AssetsPath.RoadGeneratorPath).GetComponent<RoadGenerator>();
            roadGenerator.Constructor(roadConfig.RoadFullLenght, roadConfig.RoadSectionLenght, roadFactory, coinsFactory);
        }

        private IInputService RegisterInputService()
        {
            return new InputMouse();
        }

        private GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
    }
}