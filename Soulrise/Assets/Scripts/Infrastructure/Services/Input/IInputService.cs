using UnityEngine;

namespace Infrastructure.Services.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }

        bool IsJumpButtonUp();
        bool IsFirstStanceButtonUp();
        bool IsSecondStanceButtonUp();
    }
}
