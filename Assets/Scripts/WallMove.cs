using UnityEngine;

public class WallMove : MonoBehaviour
{
    [Header("Miss Count")]
    [Tooltip("�Q�[���I�[�o�[�ɂȂ鎸�s�񐔂�ݒ肵�Ă�������")]
    [SerializeField]
    int miss = 5;

    [Header("GameOver")]
    [SerializeField]
    GameObject timer;

    private Vector3 basepos;//�����ʒu
    private Vector3 rate;//�ǂ̐i�ޑ傫��
    void Start()
    {
        basepos = transform.position;
        rate = (new Vector3(0, 0, 0) - basepos) / miss;
    }

    public void WallForward()
    {
        if (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) - rate.magnitude*2 > 0)
        {
            Debug.Log("�ǂ�������");
            transform.position += rate;
        }
        else
        {
            timer.GetComponent<Timer>().TimerStop();
            //�Q�[���I�[�o�[�̑���
        }
    }

    public void WallBack()
    {
        if (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) - Vector3.Distance(basepos, new Vector3(0, 0, 0)) < 0)
        {//(0,0,0)�Ǝ����̍��W�A�����ʒu�̋����̍������
            Debug.Log("�ǂ�����������");
            transform.position -= rate;
        }
    }
}
