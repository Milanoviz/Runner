using System;
using UnityEngine;

namespace CodeBase.GameData.Road.Models
{
    [Serializable]
    public class RoadDataModel
    {
        [SerializeField] private GameObject _roadTemplate;
        [SerializeField] private GameObject _finishRoadTemplate;

        public GameObject RoadTemplate => _roadTemplate;
        public GameObject FinishRoadTemplate => _finishRoadTemplate;
    }
}