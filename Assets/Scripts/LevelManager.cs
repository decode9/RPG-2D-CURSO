using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadNextLevel(){


        int lastIndex = SceneManager.sceneCountInBuildSettings;
        Debug.Log(lastIndex);

        int actualIndex = SceneManager.GetActiveScene().buildIndex;

        int nextIndex = ++actualIndex;
        
        if(lastIndex != nextIndex + 1) SceneManager.LoadScene(nextIndex);

    }
}
