using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

public class PlayerMove : MonoBehaviour
{
    [Header("Speed/Frame")]
    [Tooltip("スピード倍率を設定してください")]
    [SerializeField]
    float speed = 0.5f;

    [Header("PressureWall Settings")]
    [Tooltip("壁のプレハブを設定してください")]
    [SerializeField]
    GameObject wall;

    [Header("GameDirector")]
    [SerializeField]
    GameObject director;

    private float hori, ver;
    private bool startmove = false;
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
            Debug.Log("応援を受けた");

            wall.GetComponent<PressureWall>().WallBack();
            director.GetComponent<GameDirector>().ScoreUp();

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Obstruction")
        {
            Debug.Log("批判を受けた");

            wall.GetComponent<PressureWall>().WallForward();
            director.GetComponent<GameDirector>().ScoreDown();
            Destroy(collision.gameObject);
        }
    }

    public void StartMove()
    {
        startmove = true;
    }
}
