using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Speed")]
    [Tooltip("スピード倍率を設定してください")]
    [SerializeField]
    float speed = 0.5f;
    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        transform.position += (Vector3.right * hori + Vector3.up * ver) * speed;
    }
}
