using UnityEngine;
using System.Collections.Generic;

public class PressureWall : MonoBehaviour
{
    [Header("Wall Settings")]
    [Tooltip("�ǂ�ݒ肵�Ă�������")]
    [SerializeField]
    List<GameObject> list;

    /*[Header("Support Spawner")]
    [SerializeField]
    GameObject support;
    //�ǂ̔����ŃX�|�[���Ԋu���𒲐�����\��
    [Header("Obstruction Spawner")]
    [SerializeField]
    GameObject ob;*/

    private const int miss = 6;//�ǂ������ő�񐔁iHP�I�Ȉ����j
    public static int Miss { get { return miss; } }

    private static float missCount = 0;

    [Header("Timer")]
    [SerializeField]
    GameObject timer;

    [Header("Camera")]
    [SerializeField]
    GameObject cam;

    [Header("BackGround")]
    [SerializeField]
    GameObject bg;

    public void WallForward()
    {
        if (missCount < miss)
        {
            Debug.Log("�ǂ�������");
            foreach (var wall in list)
            {
                wall.GetComponent<WallMove>().WallForward();
            }

            cam.GetComponent<CameraController>().ZoomIn();

            missCount++;
            if (2 <= missCount && missCount < 4)
            {
                bg.GetComponent<BackGround>().BGListForward(0, 1);
            }
            else if (4 <= missCount && missCount < 6)
            {
                bg.GetComponent<BackGround>().BGListForward(1, 2);
            }
            else if (6 <= missCount)
            {
                bg.GetComponent<BackGround>().BGListForward(2, 3);
            }
        }
        else
        {
            timer.GetComponent<Timer>().TimerStop();
        }
    }

    public void WallBack()
    {
        if (missCount > 0)
        {
            Debug.Log("�ǂ�����������");
            foreach (var wall in list)
            {
                wall.GetComponent<WallMove>().WallBack();
            }

            cam.GetComponent<CameraController>().ZoomOut();

            missCount-=0.5f;
            if (0 < missCount && missCount < 2)
            {
                bg.GetComponent<BackGround>().BGListBack(0, 1);
            }
            else if (2 <= missCount && missCount < 4)
            {
                bg.GetComponent<BackGround>().BGListBack(1, 2);
            }
            else if (4 <= missCount && missCount < 6)
            {
                bg.GetComponent<BackGround>().BGListBack(2, 3);
            }
        }
    }

    void BGChange()
    {
        if (2 <= missCount && missCount < 4)
        {
            bg.GetComponent<BackGround>().BGListForward(0, 1);
        }
        else if (4 <= missCount && missCount < 5)
        {
            bg.GetComponent<BackGround>().BGListForward(1, 2);
        }
        else if (5 <= missCount && missCount < 6)
        {
            bg.GetComponent<BackGround>().BGListForward(2, 3);
        }
    }
}
