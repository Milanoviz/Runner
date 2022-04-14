using System;
using UnityEngine;

namespace CodeBase.GameData.Coins.Models
{
    [Serializable]
    public class CoinsDataModel
    {
        [SerializeField] private GameObject _coinTemplate;

        [Header("Options")]
        [SerializeField] private int _coinsLineCountInRoadSection = 5;
        [SerializeField] private float _distanceBetweenCoinsLine = 10;

        [SerializeField] private float _lineOffset = 3;
        [SerializeField] private float _coinHeight = 1;

        public GameObject CoinTemplate => _coinTemplate;
        public int CoinsLineCountInRoadSection => _coinsLineCountInRoadSection;
        public float DistanceBetweenCoinsLine => _distanceBetweenCoinsLine;
        public float LineOffset => _lineOffset;
        public float CoinHeight => _coinHeight;
    }
}