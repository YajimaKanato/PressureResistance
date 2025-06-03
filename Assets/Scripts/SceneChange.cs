using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [Header("AudioClip")]
    [Tooltip("�V�[���J�ڌ�ɖ炷BGM��ݒ肵�Ă�������")]
    [SerializeField]
    AudioClip clip;

    [Header("BGMManager")]
    [SerializeField]
    BGMManager bgmManager;
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        bgmManager.SoundChange(clip);
    }
}
