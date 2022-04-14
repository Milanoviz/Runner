using CodeBase.GameData.Coins;
using UnityEngine;

namespace CodeBase.Services.Coins
{
    public class CoinsFactory
    {
        private GameObject _coinTemplate;

        private readonly int _coinsLineCountInRoadSection;
        private readonly float _distanceBetweenCoinsLine;
        private readonly float _lineOffset;
        private readonly float _coinHeight;
        
        public CoinsFactory(CoinsConfig config)
        {
            _coinTemplate = config.DataModel.CoinTemplate;
            _coinsLineCountInRoadSection = config.DataModel.CoinsLineCountInRoadSection;
            _distanceBetweenCoinsLine = config.DataModel.DistanceBetweenCoinsLine;
            _lineOffset = config.DataModel.LineOffset;
            _coinHeight = config.DataModel.CoinHeight;
        }

        public void GenerateCoinsForRoadSection(Transform parent)
        {
            for (int i = 0; i < _coinsLineCountInRoadSection; i++)
            {
                var randomIndexLineType = Random.Range(-1, 2);
                var spawnPointZ = parent.position.z + i * _distanceBetweenCoinsLine;
                var spawnPoint = new Vector3(randomIndexLineType * _lineOffset, _coinHeight, spawnPointZ);
                
                CreateCoinsLine(spawnPoint, parent);
                
            }
        }

        private void CreateCoinsLine(Vector3 spawnPoint, Transform parent)
        {
            var coinPos = Vector3.zero;

            for (int i = -_coinsLineCountInRoadSection / 2; i < _coinsLineCountInRoadSection / 2; i++)
            {
                coinPos.z = i * (_distanceBetweenCoinsLine / _coinsLineCountInRoadSection);
                var coins = Object.Instantiate(_coinTemplate, parent);
                coins.transform.position = coinPos + spawnPoint;
            }
        }
    }
}