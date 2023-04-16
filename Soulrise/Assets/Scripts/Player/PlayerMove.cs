using System;
using Infrastructure.Services.Input;
using Static;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        public float MovementSpeed;

        private PlayerController2D _playerController;
        private IInputService _input;

        private void Start()
        {
            //temp
            _input = ProjectContext.Instance.Container.Resolve<IInputService>();
            //
            _playerController = GetComponent<PlayerController2D>();

        }

        private void Update()
        {
            Vector2 movementVector = Vector2.zero;

            if (_input.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = _input.Axis;
                movementVector.y = 0;
                movementVector.Normalize();
            }

            //movementVector += Physics2D.gravity;
            _playerController.Move(MovementSpeed * movementVector);
        }
    }
}
