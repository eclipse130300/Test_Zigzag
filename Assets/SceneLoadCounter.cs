using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// copyPaste
public class SceneLoadCounter : MonoBehaviour
{
    public static int SceneLoadCount { get; private set; }
    private static SceneLoadCounter instance;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        SceneLoadCount = 0;
        SceneManager.sceneLoaded += IncrementSceneLoad;
    }

    private void IncrementSceneLoad(Scene scene, LoadSceneMode mode)
    {
        SceneLoadCount++;
    }
}
