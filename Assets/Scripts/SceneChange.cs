using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [Header("AudioClip")]
    [Tooltip("シーン遷移後に鳴らすBGMを設定してください")]
    [SerializeField]
    AudioClip clip;

    [Header("BGMManager")]
    [SerializeField]
    BGMManager bgmManager;
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        //bgmManager.SoundChange(clip);
    }
}
