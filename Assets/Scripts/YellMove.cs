using UnityEngine;

public class YellMove : MonoBehaviour
{
    [Header("Radius")]
    [Tooltip("���a��ݒ肵�Ă�������")]
    [SerializeField]
    float radius = 10.5f;

    [Header("Speed")]
    [Tooltip("�X�s�[�h�{����ݒ肵�Ă�������")]
    public float speed = 1.0f;

    private float theta;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theta = Random.Range(0, 2 * Mathf.PI);
        transform.position = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)) * radius;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Mathf.Cos(theta + Mathf.PI), Mathf.Sin(theta + Mathf.PI)) * 0.1f * speed;
    }
}
