using System;
using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerJump : MonoBehaviour
    {
        public float JumpForce;
        
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
            if(_input.IsJumpButtonUp())
                _playerController.Jump(JumpForce);
        }
    }
}
