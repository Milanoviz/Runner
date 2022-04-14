using CodeBase.GameData.Road.Models;
using UnityEngine;

namespace CodeBase.GameData.Road
{
    [CreateAssetMenu(fileName = "RoadsConfig", menuName = "Configs/Roads", order = 1)]
    public class RoadsConfig : ScriptableObject
    {
        [SerializeField] private RoadDataModel _dataModel;
        [SerializeField] private int _roadFullLenght;
        [SerializeField] private int _roadSectionLenght;
        
        public RoadDataModel DataModel => _dataModel;
        public int RoadFullLenght => _roadFullLenght;
        public int RoadSectionLenght => _roadSectionLenght;
    }
}