using System;
using CodeBase.Coins;
using CodeBase.GameData.Hero;
using CodeBase.Services.InputService;
using CodeBase.Services.Score;
using UnityEngine;

namespace CodeBase.HeroModule
{
    public class Hero : MonoBehaviour
    {
        public event EventHandler CollectedCoin;
        public event EventHandler LevelCompleted;
        
        [SerializeField] private Animator _animator;

        private IHeroMover _heroMover;
        private HeroAnimator _heroAnimator;
        private IScoreService _scoreService;
        
        public void Constructor(IInputService inputService, IScoreService scoreService, HeroConfig heroConfig)
        {
            _heroMover = new HeroMover(inputService, transform, heroConfig);
            _heroAnimator = new HeroAnimator(this, _animator, inputService);
            _scoreService = scoreService;
        }
        
        private void Update()
        {
            _heroMover.Update();
            _heroAnimator.Update();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Coin>(out var coin))
            {
                coin.gameObject.SetActive(false);
                
                _scoreService.AddScore(1);

                OnCollectedCoin();
            }

            if (collision.gameObject.CompareTag("Finish"))
            {
                collision.gameObject.SetActive(false);
                
                OnLevelCompleted();
            }
        }

        private void OnCollectedCoin()
        {
            CollectedCoin?.Invoke(this, EventArgs.Empty);
        }

        private void OnLevelCompleted()
        {
            LevelCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}