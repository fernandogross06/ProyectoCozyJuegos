using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float sceneFadeDuration;
   // [SerializeField] private float blackScreenDuration;
    
    
    private SceneFade sceneFade;

    private void Awake()
    {
        sceneFade = GetComponentInChildren<SceneFade>();
    }

   
    private IEnumerator Start()
    {
        yield return sceneFade.FadeInCoroutine(sceneFadeDuration);
    }

    public void loadScene(string sceneName)
    {
        StartCoroutine(loadSceneCoroutine(sceneName));

    }

    private IEnumerator loadSceneCoroutine(string sceneName)
    {
        yield return sceneFade.FadeOutCoroutine(sceneFadeDuration);

       
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
