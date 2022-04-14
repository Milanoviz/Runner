using System;
using CodeBase.Services.InputService;
using UnityEngine;

namespace CodeBase.HeroModule
{
    public class HeroAnimator
    {
        private readonly int _moveHash = Animator.StringToHash("Move");
        private readonly int _winHash = Animator.StringToHash("Win");
        
        private readonly IInputService _inputService;
        private readonly Animator _animator;

        public HeroAnimator(Hero hero, Animator animator, IInputService inputService)
        {
            _animator = animator;
            _inputService = inputService;
            
            hero.LevelCompleted += HandlerLevelCompleted;
        }

        public void Update()
        {
            _animator.SetBool(_moveHash, _inputService.IsMoving);
        }

        private void HandlerLevelCompleted(object sender, EventArgs e)
        {
            _animator.Play(_winHash);
        }
    }
}