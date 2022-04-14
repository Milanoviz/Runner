using System;
using UnityEngine;

namespace CodeBase.GameData.Hero.Models
{
    [Serializable]
    public class HeroDataModel
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        public float MoveSpeed => _moveSpeed;
        public float RotationSpeed => _rotationSpeed;
    }
}