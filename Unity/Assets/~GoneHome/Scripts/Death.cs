using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoneHome
{
    public class Death : MonoBehaviour
    {
        public UnityEvent onDeath;
        

        // Detect collision with other triggers
        void OnTriggerEnter(Collider other)
        {
            // Have we hit a death zone or an enemy
            if (other.name == "DeathZone" || other.name == "Enemy")
            {
                // Kill object
                onDeath.Invoke();
            }
        }

    }
}