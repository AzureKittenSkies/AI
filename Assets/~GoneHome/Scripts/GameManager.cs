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
            // Get the current active scene
            Scene currentScene = SceneManager.GetActiveScene();
            // Load the current scene
            SceneManager.LoadScene(currentScene.buildIndex);
        }

    }
}