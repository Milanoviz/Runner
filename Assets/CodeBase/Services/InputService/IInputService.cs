using System;

namespace CodeBase.Services.InputService
{
    public interface IInputService
    {
        event EventHandler Move;
        
        bool IsMoving { get; }
        
        void Update();
    }
}