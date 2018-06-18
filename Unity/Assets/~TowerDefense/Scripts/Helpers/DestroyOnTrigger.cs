using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class DestroyOnTrigger : MonoBehaviour
    {

        public string nameContains;

        void OnTriggerEnter(Collider other)
        {
            // detect 'nameContains' in name string
            if (other.name.Contains(nameContains))
            {
                // kill off gameObjects
                Destroy(other.gameObject);
            }
        }



    }
}