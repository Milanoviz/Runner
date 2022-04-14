using CodeBase.GameData.Coins.Models;
using UnityEngine;

namespace CodeBase.GameData.Coins
{
    [CreateAssetMenu(fileName = "CoinsConfig", menuName = "Configs/Coins", order = 1)]
    public class CoinsConfig : ScriptableObject
    {
        [SerializeField] private CoinsDataModel _dataModel;

        public CoinsDataModel DataModel => _dataModel;
    }
}