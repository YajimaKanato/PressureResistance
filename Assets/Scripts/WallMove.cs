using UnityEngine;

public class WallMove : MonoBehaviour
{
    [Header("Parent Object")]
    [Tooltip("�e�I�u�W�F�N�g��ݒ肵�Ă�������")]
    [SerializeField]
    GameObject parent;

    private float miss;
    private Vector3 basePos;
    private Vector3 rate;//�ǂ̐i�ޑ傫��
    void Start()
    {
        miss = PressureWall.Miss + 4;//+4�͍s���\�̈�ɗ]�T���������邽��
        basePos = transform.position;
        rate = (new Vector3(0, 0, 0) - basePos) / miss;//(0,0,0)�܂ł̋�����miss+2�̉񐔂Ŋ��邱�Ƃŋϓ��ɐi��
    }

    public void WallForward()
    {
        if (Vector3.Distance(new Vector3(0, 0, 0), transform.position) > rate.magnitude)
        {
            transform.position += rate;
        }
    }

    public void WallBack()
    {
        if (Vector3.Distance(new Vector3(0, 0, 0), transform.position) < (rate * miss).magnitude)
        {
            transform.position -= rate / 2;
        }
    }
}
