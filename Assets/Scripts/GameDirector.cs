using UnityEngine;

public class GameDirector : MonoBehaviour
{
    [Header("ScoreManager")]
    [SerializeField]
    GameObject scoreManager;

    private static int score;
    public static int Score { get{ return score; } }
    void Start()
    {
        Application.targetFrameRate = 60;
        score = 0;
    }

    public void ScoreUp()
    {
        Debug.Log("ScoreUp");
        score += 100;
        scoreManager.GetComponent<ScoreManager>().ScoreChange();
    }

    public void ScoreDown()
    {
        Debug.Log("ScoreDown");
        score -= 100;
        scoreManager.GetComponent<ScoreManager>().ScoreChange();
    }
}
