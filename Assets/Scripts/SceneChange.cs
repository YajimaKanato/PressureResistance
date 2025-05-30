using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField]
    string sceneName = null;
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
