using CodeBase.Services.Coins;
using UnityEngine;

namespace CodeBase.Services.Map
{
    public class RoadGenerator : MonoBehaviour
    {
        private float _spawnPoint;
        private int _roadFullLenght;
        private float _roadSectionLenght;
        
        private RoadSectionFactory _roadSectionFactory;
        private CoinsFactory _coinsFactory;

        public void Constructor(int roadLenght, float roadSectionLenght, RoadSectionFactory roadSectionFactory, CoinsFactory coinsFactory)
        {
            _roadFullLenght = roadLenght;
            _roadSectionLenght = roadSectionLenght;
            _roadSectionFactory = roadSectionFactory;
            _coinsFactory = coinsFactory;

            Generate();
        }
        
        private void Generate()
        {
            for (int i = 0; i < _roadFullLenght; i++)
            {
                var roadSection = i != _roadFullLenght - 1 
                    ? _roadSectionFactory.CreateDefaultRoadItem(transform.forward * _spawnPoint, transform) 
                    : _roadSectionFactory.CreateFinishingRoadItem(transform.forward * _spawnPoint, transform);

                if (i != 0)
                {
                    _coinsFactory.GenerateCoinsForRoadSection(roadSection.transform);
                }
                
                _spawnPoint += _roadSectionLenght;
            }
        }
    }
}