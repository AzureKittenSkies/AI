using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoneHome
{
    public class Goal : MonoBehaviour
    {
        public UnityEvent onGoal;

        void OnTriggerEnter(Collider other)
        {
            // When player enters goal
            if (other.name.Contains("Player"))
            {
                // Call event
                onGoal.Invoke();
            }
        }
    }
}