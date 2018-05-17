using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 5f;
        public int health = 100;
        public int damage = 50;
        public float maxVelocity = 5f;
        public float maxSlopeAngle = 45f;
        [Header("Grounding")] // Attributes
        public float rayDistance = .25f;
        public bool isGrounded = false;
        public bool isOnSlope = false;
        [Header("Crouch")]
        public bool isCrouching = false;
        [Header("Jump")]
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public bool isJumping = false;
        [Header("Climb")]
        public float climbSpeed = 5f;
        public bool isClimbing = false;

        private Vector3 groundNormal = Vector3.up;
        private int currentJump = 0;
        private float inputH, inputV;

        // References
        private SpriteRenderer rend;
        private Rigidbody2D rigid;

        #region Unity Functions
        // Use this for initialization
        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
            rigid = GetComponent<Rigidbody2D>();
        }
        // Update is called once per frame
        void Update()
        {
            // Constantly update player mechanics
            PerformMove();
        }
        void FixedUpdate()
        {

        }
        void OnDrawGizmos()
        {
            // Draw the ground ray
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
            // Draw the 'right' direction
            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position - right,
                            transform.position + right);
        }
        #endregion

        #region Custom Functions
        // Inputs
        public void Jump()
        {

        }
        public void Crouch()
        {

        }
        public void UnCrouch()
        {

        }
        public void Move(float horizontal)
        {
            // If there is horizontal input
            if(horizontal != 0)
            {
                // Flip the sprite based on input direction
                rend.flipX = horizontal < 0;
            }
            // Store the horizontal input for later
            inputH = horizontal;
        }
        public void Climb(float vertical)
        {

        }
        public void Hurt(int damage)
        {

        }
        // Actions
        void PerformClimb()
        {

        }
        void PerformMove()
        {
            // Calculate 'right' depending on ground surface normal
            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);
            // Add force in the direction of horizontal movement
            rigid.AddForce(right * inputH * speed);
            // Limit the velocity
            LimitVelocity();
        }
        void PerformJump()
        {

        }
        // Detectors
        void DetectClimbable()
        {

        }
        void DetectGround()
        {

        }
        void CheckGround(RaycastHit2D hit)
        {

        }
        void CheckEnemy(RaycastHit2D hit)
        {

        }
        // Helpers
        void LimitVelocity()
        {
            // Copy current velocity to smaller variable name
            Vector3 vel = rigid.velocity;
            // Check if velocity reached max vel
            if (vel.magnitude > maxVelocity)
            {
                // Cap the velocity
                vel = vel.normalized * maxVelocity;
            }
            // Overwrite old velocity
            rigid.velocity = vel;
        }
        void StopClimbing()
        {

        }
        void EnablePhysics()
        {

        }
        void DisablePhysics()
        {

        }
        #endregion
    }
}
