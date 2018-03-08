using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoneHome
{
    public class Player : MonoBehaviour
    {

        public float movementSpeed = 20f;
        private Rigidbody rigid;

        private Transform cam;
        private Vector3 spawnPoint;

        public float maxVelocity = 5f;

        public GameObject deathParticles;

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();
            cam = Camera.main.transform;
            // Record starting point
            spawnPoint = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }

        void Movement()
        {
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");

            Vector3 inputDir = new Vector3(inputH, 0, inputV);

            // Whereever camera is looking, move on that axis
            inputDir = Quaternion.AngleAxis(cam.eulerAngles.y, Vector3.up) * inputDir;


            /*
            // Moves the position of the rigidbody without 
            // effecting gravity
            Vector3 position = transform.position;
            position += inputDir * movementSpeed * Time.deltaTime;
            rigid.MovePosition(position);
            */

            // Add force in that direction
            rigid.AddForce(inputDir * movementSpeed);

            Vector3 vel = rigid.velocity;
            // If velovity reaches max velocity
            if (vel.magnitude > maxVelocity)
            {
                // Cap the velocity
                vel = vel.normalized * maxVelocity;
            }
            rigid.velocity = vel;

        }

        public void Reset()
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            // Placing player is starting point
            transform.position = spawnPoint;
            // Reset the velocity to zero
            rigid.velocity = Vector3.zero;
            
        }


    }

}