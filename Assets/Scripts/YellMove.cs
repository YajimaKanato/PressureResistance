using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class YellMove : MonoBehaviour
{
    [Header("Radius")]
    [Tooltip("半径を設定してください")]
    public float radius = 10.5f;//オブジェクト生成半径

    [Header("Speed")]
    [Tooltip("スピード倍率を設定してください")]
    public float speed = 1.0f;

    private float theta, range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theta = Random.Range(0, 2 * Mathf.PI);//生成座標を決める偏角
        range = Random.Range(-1, 1) * Mathf.PI / 12;//生成座標から動き出すときの角度、(0,0,0)に向かって±PI/12
        transform.position = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)) * radius;//生成座標
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
            /*Debug.Log("音が鳴った");
            AudioResource audio = GetComponent<AudioResource>();
            AudioSource.PlayClipAtPoint(audio, this.transform.position);*/
        }
    }
}
