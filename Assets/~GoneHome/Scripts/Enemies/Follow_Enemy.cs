using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GoneHome
{
    public class Follow_Enemy : MonoBehaviour
    {

        private NavMeshAgent agent;
        public Transform target;

        private Vector3 spawnPoint;

        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            spawnPoint = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(target.position);
        }

        public void Reset()
        {
            transform.position = spawnPoint;
        }

    }
}
