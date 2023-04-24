using System;
using System.Collections;
using Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerStances : MonoBehaviour
    {
        [Header("BlackStance")] 
        public float blackMoveSpeed;
        public float blackJumpHeight;
        public float blackDuration;
        
        [Header("WhiteStance")]
        public float whiteMoveSpeed;
        public float whiteJumpHeight;
        public float whiteDuration;
        
        private IInputService _input;
        private PlayerMove _move;
        private PlayerJump _jump;

        private Stance _currentStance;
        private float _defaultMoveSpeed;
        private float _defaultJumpHeight;

        private float _stanceTimer;
        private bool _notInDefaultStance;

        private void Awake()
        {
            //temp
            _input = _input = ProjectContext.Instance.Container.Resolve<IInputService>();
            //
            _move = GetComponent<PlayerMove>();
            _jump = GetComponent<PlayerJump>();

            _currentStance = Stance.Default;

            _defaultMoveSpeed = _move.MovementSpeed;
            _defaultJumpHeight = _jump.JumpForce;
        }

        private void Update()
        {
            if (_notInDefaultStance)
                return;
            
            if (_input.IsFirstStanceButtonUp())
                SwitchToBlack();

            if (_input.IsSecondStanceButtonUp())
                SwitchToWhite();
        }

        private void SwitchToBlack()
        {
            _currentStance = Stance.Black;
            _move.MovementSpeed = blackMoveSpeed;
            _jump.JumpForce = blackJumpHeight;
            StartCoroutine(StanceTimer(blackDuration));
            
            //
            Debug.Log($"Switched to {_currentStance.ToString()}");
            //
        }

        private void SwitchToWhite()
        {
            _currentStance = Stance.White;
            _move.MovementSpeed = whiteMoveSpeed;
            _jump.JumpForce = whiteJumpHeight;
            StartCoroutine(StanceTimer(whiteDuration));
            
            //
            Debug.Log($"Switched to {_currentStance.ToString()}");
            //
        }

        private void SwitchToDefault()
        {
            _currentStance = Stance.Default;
            _move.MovementSpeed = _defaultMoveSpeed;
            _jump.JumpForce = _defaultJumpHeight;

            //
            Debug.Log($"Switched to {_currentStance.ToString()}");
            //
        }

        private IEnumerator StanceTimer(float stanceTime)
        {
            _notInDefaultStance = true;
            _stanceTimer = stanceTime;
            while (_stanceTimer > 0)
            {
                _stanceTimer -= Time.deltaTime;
                yield return null;
            }
            _notInDefaultStance = false;
            SwitchToDefault();
        }
    }

    enum Stance
    {
        Default,
        Black,
        White
    }
}
