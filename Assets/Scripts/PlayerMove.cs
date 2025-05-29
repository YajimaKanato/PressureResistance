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
    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        transform.position += (Vector3.right * hori + Vector3.up * ver) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Support")
        {
            foreach (var list in wall)
            {
                list.GetComponent<WallMove>().WallBack();
            }
            Debug.Log("応援を受けた");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Obstruction")
        {
            foreach (var list in wall)
            {
                list.GetComponent<WallMove>().WallForward();
            }
            Debug.Log("批判を受けた");
            Destroy(collision.gameObject);
        }
    }
}
