using UnityEngine;

public class WallMove : MonoBehaviour
{
    [Header("Parent Object")]
    [Tooltip("親オブジェクトを設定してください")]
    [SerializeField]
    GameObject parent;

    private float miss;
    private Vector3 basePos;
    private Vector3 rate;//壁の進む大きさ
    void Start()
    {
        miss = PressureWall.Miss + 4;//+4は行動可能領域に余裕を持たせるため
        basePos = transform.position;
        rate = (new Vector3(0, 0, 0) - basePos) / miss;//(0,0,0)までの距離をmiss+2の回数で割ることで均等に進む
    }

    public void WallForward()
    {
        if (Vector3.Distance(new Vector3(0, 0, 0), transform.position) > rate.magnitude)
        {
            transform.position += rate;
        }
    }

    public void WallBack()
    {
        if (Vector3.Distance(new Vector3(0, 0, 0), transform.position) < (rate * miss).magnitude)
        {
            transform.position -= rate / 2;
        }
    }
}
