using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence
{
    public class Droid : MonoBehaviour
    {
        #region Variables

        public float health = 100;
        

        #endregion
        /// <summary>
        /// Deals damage to the droid
        /// </summary>
        /// <param name="damage">Damage to deal</param>
        public void DealDamage(float damage)
        {
            // deal damage to droid
            health -= damage;

            // if there is no health
            if (health <= 0)
            {
                // kill off gameobject
                Destroy(gameObject);
            }
        }






        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}