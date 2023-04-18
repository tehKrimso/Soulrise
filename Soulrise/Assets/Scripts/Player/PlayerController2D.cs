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
        
        private const float GroundCheckRadius = 0.2f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(float movement)
        {
            _rigidbody.velocity = new Vector2(movement, _rigidbody.velocity.y);
            
            if(movement > 0 && !_isFacingRight)
                Flip();
            else if(movement < 0 && _isFacingRight)
                Flip();
        }

        public void Jump(float jumpForce)
        {
            if(IsGrounded())
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }
        
        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        private bool IsGrounded() => Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayers);
    }
}
