using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    void Start()
    {
        text=GetComponent<Text>();
        text.text = "" + GameDirector.Score;
    }
}
