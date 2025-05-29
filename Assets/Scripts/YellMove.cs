using UnityEngine;

public class YellMove : MonoBehaviour
{
    [Header("Radius")]
    [Tooltip("半径を設定してください")]
    [SerializeField]
    float radius = 10.5f;

    [Header("Speed")]
    [Tooltip("スピード倍率を設定してください")]
    public float speed = 1.0f;

    private float theta, range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theta = Random.Range(0, 2 * Mathf.PI);
        range = Random.Range(-1, 1) * Mathf.PI / 12;
        transform.position = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)) * radius;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Mathf.Cos(theta + Mathf.PI + range), Mathf.Sin(theta + Mathf.PI + range)) * 0.1f * speed;
    }
}
