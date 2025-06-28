using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollect : MonoBehaviour
{
    public int fruitCount = 0;
    public int targetFruits = 5; // How many to win


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fruit"))
        {
            fruitCount++;
            Destroy(other.gameObject);

            // Check if target reached
            if (fruitCount >= targetFruits)
            {
                LevelComplete();
            }
        }
    }

    void LevelComplete()
    {
        Debug.Log("Level Complete!");

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex + 1 < totalScenes)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("Last scene reached. Quitting game...");
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
