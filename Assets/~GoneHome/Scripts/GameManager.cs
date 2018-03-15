using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace GoneHome
{ 
    public class GameManager : MonoBehaviour
    {

        public void NextLevel()
        {
            // Get the current active scene
            Scene currentScene = SceneManager.GetActiveScene();
            // Load the next build index
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }

        public void RestartLevel()
        {
            // Grab all enemies in the scene into array
            Follow_Enemy[] followEnemies = FindObjectsOfType<Follow_Enemy>();
            Patrol_Enemy[] patrolEnemies = FindObjectsOfType<Patrol_Enemy>();

            // Loop through all enemies
            foreach (var enemy in followEnemies)
            {
                // Reset enemy
                enemy.Reset();
            }

            foreach (var enemy in patrolEnemies)
            {
                enemy.Reset();
            }

            // Grab player in the scene
            Player player = FindObjectOfType<Player>();
            // reset player
            player.Reset();
        }


    }
}