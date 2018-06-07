using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    // tower is a monobehaivour
    public class Tower : MonoBehaviour
    {
        #region Variables
        public float damage = 10f;
        public float attackDelay = 1f;

        // tower has an enemy
        protected Enemy currentEnemy;

        private float attackTimer = 0;




        #endregion

        public virtual void Aim(Enemy e) { }
        public virtual void Attack(Enemy e) { }

        protected virtual void Update()
        {
            attackTimer += Time.deltaTime;
            // if there is a currentEnemy the tower is targeting
            if (currentEnemy)
            {
                // aim at current enemy
                Aim(currentEnemy);
                if (attackTimer >attackDelay)
                {
                    // attack the current enemy
                    Attack(currentEnemy);
                    attackTimer = 0f;
                }
            }
        }

        void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy!= null && currentEnemy == null)
            {
                currentEnemy = enemy;
            }
        }

        void OnTriggerExit(Collider other)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null && currentEnemy == enemy)
            {

            }
        }
    }
}