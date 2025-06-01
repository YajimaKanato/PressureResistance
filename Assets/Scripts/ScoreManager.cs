using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "" + GameDirector.Score;
    }

    public void ScoreChange()
    {
        text.text = "" + GameDirector.Score;
    }
}
