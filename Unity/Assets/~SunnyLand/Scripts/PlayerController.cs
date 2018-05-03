using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SunnyLand
{
    public class PlayerController : MonoBehaviour
    {

        #region Variables

        public float speed = 5f;
        public int health = 100;
        public int damage = 50;
        public float hitForce = 4f;
        public float damageForce = 4f;
        public float maxVelocity;
        public float maxSlopeAngle = 45f;

        [Header("Grounding")]
        public float rayDistance = .5f;
        public bool isGrounded = false;
        public bool isOnSlope = false;

        [Header("Crouch")]
        public bool isCrouching = false;
        [Header("Jump")]
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public bool isJumping = false;

        private Vector3 groundNormal = Vector3.up;
        private int currentJump = 0;

        private float inputH, inputV;

        // References 
        private SpriteRenderer rend;
        private Animator anim;
        private Rigidbody2D rigid;


        public delegate void EventCallback();
        public delegate void FloatCallback(float value);
        // Delegates
        public EventCallback onJump;
        public FloatCallback onMove;
        public FloatCallback onClimb;



        #endregion

        #region Unity Functions
        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            PerformMove();
            PerformJump();
        }

        void FixedUpdate()
        {
            DetectGround();
        }

        void OnDrawGizmos()
        {
            // drawn ground ray 
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);

            // draw direction of movement
            Vector3 right = Vector3.Cross(groundNormal, Vector3.back);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position - right * 1f, transform.position + right * 1f);
        }

        #endregion


        #region Custom Functions
        public void Jump()
        {
            isJumping = true;
        }
        public void Crouch()
        {

        }
        public void UnCrouch()
        {

        }
        public void Move(float horizontal)
        {
            // if there is horizontal input
            if (horizontal != 0)
            {
                // flip sprite in current direction
                rend.flipX = horizontal < 0;
            }

            // store input horizontal for performing movement later
            inputH = horizontal;

            if (onMove != null)
            {
                // run all subscribed functions
                // and pass 'horizontal' as argument
                onMove.Invoke(horizontal);
            }

        }
        public void Hurt(int damage)
        {

        }

        private void PerformClimb()
        {

        }
        private void PerformMove()
        {
            if (isOnSlope && isGrounded)
            {
                rigid.drag = 5f;
            }
            else
            {
                rigid.drag = 0f;
            }

            Vector3 right = Vector3.Cross(groundNormal, Vector3.forward);

            // add force in direction of horizontal movement
            rigid.AddForce(right * inputH * speed);

            // limit velocity
            LimitVelocity();
        }
        private void PerformJump()
        {
            // check if jumpint is supposed to happen
            if (isJumping)
            {
                currentJump++;

                // if current jump is less than max jump count
                if (currentJump < maxJumpCount)
                {

                    // perform jump logic
                    rigid.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
                }
                // reset jump
                isJumping = false;
            }
        }
        private bool CheckGround(RaycastHit2D hit)
        {
            // if hit is not null and hit isn't self and hit isnt' a trigger
            if (hit.collider != null && !(hit.collider.name == name) && hit.collider.isTrigger == false)
            {
                // reset jump
                currentJump = 0;
                isGrounded = true;
                // update ground normal
                groundNormal = hit.normal;

                // calculate slope angle
                float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
                // check if slope is within range of aprameters
                if (Mathf.Abs(slopeAngle) > 0 && Mathf.Abs(slopeAngle) < maxSlopeAngle)
                {
                    isOnSlope = true;
                }
                else
                {
                    isOnSlope = false;
                }
                // check if maximum slope angle
                if (Mathf.Abs(slopeAngle) >= maxSlopeAngle)
                {

                }
                return true;
            }

            return false;
        }
        private void CheckEnemy(RaycastHit2D hit)
        {

        }
        private void DetectGround()
        {
            // create ray going in the direction of down
            Ray groundRay = new Ray(transform.position, Vector3.down);
            // get all the hit objects (perform raycast all)
            RaycastHit2D[] hits = Physics2D.RaycastAll(groundRay.origin, groundRay.direction, rayDistance);
            // for each hit in the list
            foreach (var hit in hits)
            {

                // checkenemy(hit)
                CheckEnemy(hit);

                if (inputH != 0)
                {
                    float dir = hit.normal.x * inputH;
                    if (dir > 0.1f)
                    {
                        print("GOING DOWN!");
                    }
                    else if (dir < -0.1f)
                    {
                        print("GOING UP!");
                    }
                }

                // detect slope
                if (Mathf.Abs(hit.normal.x) > 0.1f)
                {
                    rigid.gravityScale = 0;
                }
                else
                {
                    rigid.gravityScale = 1;
                }

                // breaks from loop at the first layer of ground
                if (CheckGround(hit))
                {
                    return;
                }

            }
        }
        private void LimitVelocity()
        {
            // normalising velocity vectors 
            Vector3 vel = rigid.velocity;
            if (vel.magnitude >= maxVelocity)
            {
                vel = vel.normalized * maxVelocity;
            }


            rigid.velocity = vel;
        }
        private void StopClimbing()
        {

        }
        private void EnablePhysics()
        {
            rigid.simulated = true;
            rigid.gravityScale = 1;
        }
        private void DisablePhysics()
        {
            rigid.simulated = false;
            rigid.gravityScale = 0;
        }

        #endregion


    }
}