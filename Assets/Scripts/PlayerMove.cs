using UnityEngine;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour
{
    [Header("Speed")]
    [Tooltip("�X�s�[�h�{����ݒ肵�Ă�������")]
    [SerializeField]
    float speed = 0.5f;

    [Header("Wall Settings")]
    [Tooltip("�ǂ̃v���n�u��ݒ肵�Ă�������")]
    [SerializeField]
    GameObject[] wall;//WallMove�N���X���擾

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
        //�ǂ̌������ɂ����Ȃ��悤�ȏ���
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Support")
        {
            foreach (var list in wall)
            {
                list.GetComponent<PressureWall>().WallBack();
            }
            Debug.Log("�������󂯂�");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Obstruction")
        {
            foreach (var list in wall)
            {
                list.GetComponent<PressureWall>().WallForward();
            }
            Debug.Log("�ᔻ���󂯂�");
            Destroy(collision.gameObject);
        }
    }

    public void StartMove()
    {
        startmove = true;
    }
}
