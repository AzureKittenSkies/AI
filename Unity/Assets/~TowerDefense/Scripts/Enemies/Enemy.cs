using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        #region Variables

        public float maxHealth = 100;
        [Header("UI")]
        public GameObject healthBarUI;
        public Vector2 healthBarOffset = new Vector2(0, 5f);

        private Slider healthSlider;
        private float health = 100f;

        #endregion

        void Start()
        {
            health = maxHealth;

        }

        void Update()
        {
            // if a health slider exists
            if (healthSlider)
            {
                // update health slider's position
                healthSlider.transform.position = GetHealthBarPos();
            }
        }

        Vector3 GetHealthBarPos()
        {
            Camera cam = Camera.main;
            // converts world position to screen
            Vector3 position = cam.WorldToScreenPoint(transform.position);
            // returns screen positoin + offset (in pixels)
            return position + (Vector3)healthBarOffset;
        }

        public void SpawnHealthBar(Transform parent)
        {
            // spawn a new health bar under given parent
            GameObject clone = Instantiate(healthBarUI, GetHealthBarPos(), Quaternion.identity, parent);
            // store the slider component for later use
            healthSlider = clone.GetComponent<Slider>();
        }


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



    }
}