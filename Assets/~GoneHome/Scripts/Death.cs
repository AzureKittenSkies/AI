using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoneHome
{
    public class Death : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        void Died()
        {
            // Play animation
            // Spawn particles
            // Perform other events
        }

        // Detect collision with other triggers
        void OnTriggerEnter(Collider other)
        {
            // Have we hit a death zone or an enemy
            if (other.name == "DeathZone" || other.name == "Enemy")
            {
                // Kill object
                Died();
            }
        }

    }
}