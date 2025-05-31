using UnityEngine;

public class WallMove : MonoBehaviour
{
    [Header("Miss Count")]
    [Tooltip("�Q�[���I�[�o�[�ɂȂ鎸�s�񐔂�ݒ肵�Ă�������")]
    [SerializeField]
    int miss = 10;

    [Header("GameOver")]
    [SerializeField]
    GameObject timer;

    [SerializeField]
    GameObject cam;

    private float rate;//�ǂ̐i�ޑ傫��
    void Start()
    {
        rate = 1.0f / miss;
    }

    public void WallForward()
    {
        if (transform.localScale.x > rate && transform.localScale.y > rate)
        {
            Debug.Log("�ǂ�������");
            transform.localScale -= new Vector3(rate, rate, 0);
        }
        else
        {
            timer.GetComponent<Timer>().TimerStop();
            //�Q�[���I�[�o�[�̑���
        }
    }

    public void WallBack()
    {
        if (transform.localScale.x < 1 && transform.localScale.y < 1)
        {
            Debug.Log("�ǂ�����������");
            transform.localScale += new Vector3(rate, rate, 0);
        }
    }
}
