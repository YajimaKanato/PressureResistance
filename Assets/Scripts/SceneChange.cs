using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [Header("AudioClip")]
    [Tooltip("ƒV[ƒ“‘JˆÚŒã‚É–Â‚ç‚·BGM‚ğİ’è‚µ‚Ä‚­‚¾‚³‚¢")]
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
