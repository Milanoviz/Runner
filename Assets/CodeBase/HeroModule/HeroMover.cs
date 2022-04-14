using System;
using CodeBase.GameData.Hero;
using CodeBase.Services.InputService;
using UnityEngine;

namespace CodeBase.HeroModule
{
    public class HeroMover : IHeroMover
    {
        private readonly float _moveSpeed;
        private readonly float _rotationSpeed;
        
        private readonly Transform _heroTransform;
        private readonly IInputService _inputService;
        private readonly Camera _camera;

        public HeroMover(IInputService inputService, Transform heroTransform, HeroConfig heroData)
        {
            _inputService = inputService;
            _heroTransform = heroTransform;
            _camera = Camera.main;

            _moveSpeed = heroData.DataModel.MoveSpeed;
            _rotationSpeed = heroData.DataModel.RotationSpeed;
            
            _inputService.Move += HandlerMove;
        }

        public void Update()
        {
            _inputService.Update();
        }

        private void HandlerMove(object sender, EventArgs e)
        {
            Movement();
            Rotation();
        }

        private void Movement()
        {
            var direction = _heroTransform.TransformDirection(Vector3.forward);
            _heroTransform.position += direction * _moveSpeed * Time.deltaTime;
        }
        
        private void Rotation()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_heroTransform.position);
            var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            var targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
            _heroTransform.rotation = Quaternion.Lerp(_heroTransform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}