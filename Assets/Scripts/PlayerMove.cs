using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

public class PlayerMove : MonoBehaviour
{
    [Header("Speed/Frame")]
    [Tooltip("�X�s�[�h�{����ݒ肵�Ă�������")]
    [SerializeField]
    float speed = 0.5f;

    [Header("PressureWall Settings")]
    [Tooltip("�ǂ̃v���n�u��ݒ肵�Ă�������")]
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
        //�ǂ̌������ɂ����Ȃ��悤�ȏ���
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Support")
        {
            Debug.Log("�������󂯂�");

            wall.GetComponent<PressureWall>().WallBack();
            director.GetComponent<GameDirector>().ScoreUp();

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Obstruction")
        {
            Debug.Log("�ᔻ���󂯂�");

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
