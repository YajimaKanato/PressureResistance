using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class YellMove : MonoBehaviour
{
    [Header("Radius")]
    [Tooltip("���a��ݒ肵�Ă�������")]
    public float radius = 10.5f;//�I�u�W�F�N�g�������a

    [Header("Speed")]
    [Tooltip("�X�s�[�h�{����ݒ肵�Ă�������")]
    public float speed = 1.0f;

    private float theta, range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theta = Random.Range(0, 2 * Mathf.PI);//�������W�����߂�Ίp
        range = Random.Range(-1, 1) * Mathf.PI / 12;//�������W���瓮���o���Ƃ��̊p�x�A(0,0,0)�Ɍ������ā}PI/12
        transform.position = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)) * radius;//�������W
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Mathf.Cos(theta + Mathf.PI + range), Mathf.Sin(theta + Mathf.PI + range)) * 0.1f * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            /*Debug.Log("��������");
            AudioResource audio = GetComponent<AudioResource>();
            AudioSource.PlayClipAtPoint(audio, this.transform.position);*/
        }
    }
}
