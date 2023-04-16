using UnityEngine;

namespace Infrastructure.Services.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string JumpButton = "Jump";
        protected const string FirstStanceButton = "FirstStance";
        protected const string SecondStanceButton = "SecondStance";
        
        
        public abstract Vector2 Axis { get; }
        public abstract bool IsJumpButtonUp();
        public abstract bool IsFirstStanceButtonUp();
        public abstract bool IsSecondStanceButtonUp();
    }
}