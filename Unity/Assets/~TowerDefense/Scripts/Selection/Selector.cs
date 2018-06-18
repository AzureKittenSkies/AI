using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Selector : MonoBehaviour
    {

        public GameObject[] prefabs;
        public LayerMask layerMask;

        private GameObject[] instances; // generated instances of current selection
        private Transform tower, hologram; // reference to both tower and holo
        private int currentTower;


        // filters the selection to fit within amount of towers
        public void SelectTower(int index)
        {
            // filter the index
            if (index < 0 || index > prefabs.Length)
            {
                return;
            }

            // set the new index
            currentTower = index;

        }

        void GenerateInstances()
        {
            GameObject instance = instances[currentTower];
            if (instance == null)
            {
                // create new instance
                instance = Instantiate(prefabs[currentTower]);
                // attatch to parent
                instance.transform.SetParent(transform);

                tower = instance.transform.Find("Tower");
                hologram = instance.transform.Find("Hologram");
                tower.gameObject.SetActive(false);
                hologram.gameObject.SetActive(false);

                // store new instance in array (for later use)
                instances[currentTower] = instance;
            }

        }


        void Start()
        {
            instances = new GameObject[prefabs.Length];
            // select first tower
            SelectTower(0);

        }


        void Update()
        {
            // if we've place a tower, create a new instance of another one
            GenerateInstances();

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit, 1000f, layerMask, QueryTriggerInteraction.Ignore))
            {
                Placeable p = hit.transform.GetComponent<Placeable>();
                // if placable was hit and nothing has been placed on it
                if (p && !p.isPlaced)
                {
                    GameObject gHolo = hologram.gameObject;
                    GameObject gTower = tower.gameObject;

                    // if holo is inactive, activate holo
                    if (!gHolo.activeSelf)
                    {
                        gHolo.SetActive(true);

                    }

                    GameObject instance = instances[currentTower];
                    instance.transform.position = p.transform.position;

                    // if mouse button is pressed
                    if (Input.GetMouseButtonDown(0))
                    {
                        p.isPlaced = true;

                        gHolo.SetActive(false);
                        gTower.SetActive(true);

                        instances[currentTower] = null;
                    }


                }
            }


        }

    }
}