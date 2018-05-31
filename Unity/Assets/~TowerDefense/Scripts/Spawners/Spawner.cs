using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Spawner : MonoBehaviour
    {

        #region 
        public GameObject prefab;
        public float spawnRate = 1f;

        private float timer = 0f;



        #endregion

        public virtual void Spawn()
        {

        }




        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= spawnRate)
            {
                // spawn object
                Spawn(); // call spawn here (for overrides)
                timer = 0;
            }
        }
    }
}