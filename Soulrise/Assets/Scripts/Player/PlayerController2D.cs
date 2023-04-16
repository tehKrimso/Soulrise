using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController2D : MonoBehaviour
    {
        public Transform GroundCheck;
        public LayerMask GroundLayers;

        private Rigidbody2D _rigidbody;

        private bool _isFacingRight;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 movementVector)
        {
            _rigidbody.velocity = movementVector;
            
            if(movementVector.x > 0 && !_isFacingRight)
                Flip();
            else if(movementVector.x < 0 && _isFacingRight)
                Flip();
        }

        public void Jump()
        {
            
        }
        
        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
