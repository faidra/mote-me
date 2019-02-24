using UnityEngine;
using UniRx.Async;

public class SceneManager
{
    public UniTask ChangeToAsync(string sceneName)
    {
        return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single).ToUniTask();
    }
}
