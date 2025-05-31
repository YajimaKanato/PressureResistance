using UnityEngine;

public class WallMove : MonoBehaviour
{
    [Header("Miss Count")]
    [Tooltip("ゲームオーバーになる失敗回数を設定してください")]
    [SerializeField]
    int miss = 10;

    [Header("GameOver")]
    [SerializeField]
    GameObject timer;

    [SerializeField]
    GameObject cam;

    private float rate;//壁の進む大きさ
    void Start()
    {
        rate = 1.0f / miss;
    }

    public void WallForward()
    {
        if (transform.localScale.x > rate && transform.localScale.y > rate)
        {
            Debug.Log("壁が迫った");
            transform.localScale -= new Vector3(rate, rate, 0);
        }
        else
        {
            timer.GetComponent<Timer>().TimerStop();
            //ゲームオーバーの操作
        }
    }

    public void WallBack()
    {
        if (transform.localScale.x < 1 && transform.localScale.y < 1)
        {
            Debug.Log("壁が遠ざかった");
            transform.localScale += new Vector3(rate, rate, 0);
        }
    }
}
