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
            Debug.Log("�������󂯂�");
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Obstruction")
        {
            foreach (var list in wall)
            {
                list.GetComponent<WallMove>().WallForward();
            }
            Debug.Log("�ᔻ���󂯂�");
            Destroy(collision.gameObject);
        }
    }
}
