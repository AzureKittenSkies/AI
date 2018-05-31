using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class EnemySpawner : Spawner
    {
        #region Variables
        public float spawnRadius = 1f;
        public Transform path;
        [Header("UI")]
        public Transform healthBarParent;

        private Transform start;
        private Transform end;
        #endregion


        void GetPath()
        {
            start = path.FindChild("Start");
            end = path.FindChild("End");
        }




        // Use this for initialization
        void Start()
        {
            GetPath();
        }

        void OnDrawGizmos()
        {
            GetPath();
            if (start != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(start.position, spawnRadius);
            }
        }


        // change what happens on spawn from base class
        public override void Spawn()
        {
            // create an instance of an enemy
            GameObject clone = Instantiate(prefab, start.position, start.rotation);
            // set clone under spawner as child
            clone.transform.SetParent(transform);
            // set AI agent's target to end
            AIAgent agent = clone.GetComponent<AIAgent>();
            agent.target = end;
            // spawn a health bar
            Enemy enemy = clone.GetComponent<Enemy>();
            enemy.SpawnHealthBar(healthBarParent);
        }



    }
}