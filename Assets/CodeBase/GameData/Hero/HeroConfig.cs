using CodeBase.GameData.Hero.Models;
using UnityEngine;

namespace CodeBase.GameData.Hero
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Configs/Hero", order = 1)]
    public class HeroConfig : ScriptableObject
    {
        [SerializeField] private HeroDataModel _dataModel;

        public HeroDataModel DataModel => _dataModel;
    }
}