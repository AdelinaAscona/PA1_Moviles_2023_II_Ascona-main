using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(LoadPuntajeMaxAsync());
    }

    private IEnumerator LoadPuntajeMaxAsync()
    {
        yield return null; // Espera un fotograma para evitar conflictos

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("PuntajeMax", LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}