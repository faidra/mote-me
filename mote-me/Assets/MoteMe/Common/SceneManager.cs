using UniRx.Async;

public class SceneManager
{
    public enum SceneId
    {
        Preparation,
        Main,
        Result,
        Watch,
    }

    public UniTask ChangeToAsync(SceneId sceneId)
    {
        return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneId.ToString(), UnityEngine.SceneManagement.LoadSceneMode.Single).ToUniTask();
    }
}
