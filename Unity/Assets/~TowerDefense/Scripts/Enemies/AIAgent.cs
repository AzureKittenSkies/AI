using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TowerDefense
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIAgent : MonoBehaviour
    {
        [System.NonSerialized]
        #region Variables
        public Transform target;

        private NavMeshAgent nav;

        #endregion

        void Awake()
        {
            nav = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            // if a target has been set
            if (target != null)
            {
                // navigate to the target
                nav.SetDestination(target.position);

            }
        }
    }
}