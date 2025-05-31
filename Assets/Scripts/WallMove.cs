using UnityEngine;

public class WallMove : MonoBehaviour
{
    [Header("Miss Count")]
    [Tooltip("ゲームオーバーになる失敗回数を設定してください")]
    [SerializeField]
    int miss = 5;

    [Header("GameOver")]
    [SerializeField]
    GameObject timer;

    private Vector3 basepos;//初期位置
    private Vector3 rate;//壁の進む大きさ
    void Start()
    {
        basepos = transform.position;
        rate = (new Vector3(0, 0, 0) - basepos) / miss;
    }

    public void WallForward()
    {
        if (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) - rate.magnitude*2 > 0)
        {
            Debug.Log("壁が迫った");
            transform.position += rate;
        }
        else
        {
            timer.GetComponent<Timer>().TimerStop();
            //ゲームオーバーの操作
        }
    }

    public void WallBack()
    {
        if (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) - Vector3.Distance(basepos, new Vector3(0, 0, 0)) < 0)
        {//(0,0,0)と自分の座標、初期位置の距離の差を取る
            Debug.Log("壁が遠ざかった");
            transform.position -= rate;
        }
    }
}
