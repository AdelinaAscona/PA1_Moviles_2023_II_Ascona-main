using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGlobalManager : MonoBehaviour
{
    private static SceneGlobalManager instance;

    public static SceneGlobalManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SceneGlobalManager>();

                if (instance == null)
                {
                    GameObject managerObject = new GameObject("SceneGlobalManager");
                    instance = managerObject.AddComponent<SceneGlobalManager>();
                    DontDestroyOnLoad(managerObject);
                }
            }
            return instance;
        }
    }

    public void LoadSceneAsync(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
}
