using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
                return axis;
            }
        }
        
        public override bool IsJumpButtonUp() => UnityEngine.Input.GetKeyUp(KeyCode.Space);
        public override bool IsFirstStanceButtonUp() => UnityEngine.Input.GetKeyUp(KeyCode.Q);
        public override bool IsSecondStanceButtonUp() => UnityEngine.Input.GetKeyUp(KeyCode.E);
    }
}