using UnityEngine;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    [Header("Speed")]
    [Tooltip("スピード倍率を設定してください")]
    [SerializeField]
    float speed = 0.5f;

    [Header("Wall Settings")]
    [Tooltip("壁のプレハブを設定してください")]
    [SerializeField]
    GameObject[] wall;//WallMoveクラスを取得

    private float hori, ver;
    private bool startmove=false;
    void Update()
    {
        if (startmove)
        {
            hori = Input.GetAxisRaw("Horizontal");
            ver = Input.GetAxisRaw("Vertical");
        }

        transform.position += (Vector3.right * hori + Vector3.up * ver) * speed;
        //壁の向こうにいかないような処理
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Support")
        {
            foreach (var list in wall)
            {
                list.GetComponent<PressureWall>().WallBack();
            }
            Debug.Log("応援を受けた");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Obstruction")
        {
            foreach (var list in wall)
            {
                list.GetComponent<PressureWall>().WallForward();
            }
            Debug.Log("批判を受けた");
            Destroy(collision.gameObject);
        }
    }

    public void StartMove()
    {
        startmove = true;
    }
}
