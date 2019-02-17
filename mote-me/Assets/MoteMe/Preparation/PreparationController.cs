using UnityEngine;
using UniRx;
using UniRx.Async;
using UnityEngine.UI;

public class PreparationController : MonoBehaviour
{
    [SerializeField]
    Button PlayButton;

    void Start()
    {
        PlayButton.OnClickAsObservable()
            .Subscribe(_ => GoToPlay())
            .AddTo(this);
    }

    void GoToPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("test", UnityEngine.SceneManagement.LoadSceneMode.Single).ToUniTask().Forget();
    }
}
