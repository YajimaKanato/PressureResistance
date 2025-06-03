using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [Header("SetAudioIndex")]
    [Tooltip("�V�[���J�ڌ�ɖ炷BGM���X�g�̔ԍ���ݒ肵�Ă�������")]
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
