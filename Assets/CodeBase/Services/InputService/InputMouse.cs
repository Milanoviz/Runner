using System;
using UnityEngine;

namespace CodeBase.Services.InputService
{
    public class InputMouse : IInputService
    {
        public event EventHandler Move;
        
        public bool IsMoving { get; private set; }

        public void Update()
        {
            if (Input.GetMouseButton(0))
            {
                IsMoving = true;
                
                OnMove();
            }
            else
            {
                IsMoving = false;
            }
        }
        
        private  void OnMove()
        {
            Move?.Invoke(this, EventArgs.Empty);
        }
    }
}