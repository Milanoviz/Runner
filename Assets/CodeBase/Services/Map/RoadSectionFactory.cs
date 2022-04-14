using CodeBase.GameData.Road;
using UnityEngine;

namespace CodeBase.Services.Map
{
    public class RoadSectionFactory
    {
        private readonly GameObject _roadTemplate;
        private readonly GameObject _finishRoadTemplate;

        public RoadSectionFactory(RoadsConfig roadsConfig)
        {
            _roadTemplate = roadsConfig.DataModel.RoadTemplate;
            _finishRoadTemplate = roadsConfig.DataModel.FinishRoadTemplate;
        }

        public GameObject CreateDefaultRoadItem(Vector3 spawnPoint, Transform parent)
        {
            var instance = Object.Instantiate(_roadTemplate, spawnPoint, Quaternion.identity, parent);
            return instance;
        }
        
        public GameObject CreateFinishingRoadItem(Vector3 spawnPoint, Transform parent)
        {
            var instance = Object.Instantiate(_finishRoadTemplate, spawnPoint, Quaternion.identity, parent);
            return instance;
        }
    }
}