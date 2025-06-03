using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [Header("SetAudioIndex")]
    [Tooltip("シーン遷移後に鳴らすBGMリストの番号を設定してください")]
    [SerializeField]
    int index;

    [Header("BGMManager")]
    [SerializeField]
    BGMManager bgmManager;
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        BGMManager.Index = index;
        bgmManager.SoundChange();
    }
}
