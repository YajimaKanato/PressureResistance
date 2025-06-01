using UnityEngine;
using System.Collections.Generic;

public class PressureWall : MonoBehaviour
{
    [Header("Wall Settings")]
    [Tooltip("ï«Çê›íËÇµÇƒÇ≠ÇæÇ≥Ç¢")]
    [SerializeField]
    List<GameObject> list;

    [Header("Support Spawner")]
    [SerializeField]
    GameObject support;

    [Header("Obstruction Spawner")]
    [SerializeField]
    GameObject ob;

    private const int miss = 6;//ï«Ç™îóÇÍÇÈç≈ëÂâÒêî
    public static int Miss { get { return miss; } }

    private int missCount = 0;

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
            Debug.Log("ï«Ç™îóÇ¡ÇΩ");
            foreach (var wall in list)
            {
                wall.GetComponent<WallMove>().WallForward();
            }

            cam.GetComponent<CameraController>().ZoomIn();

            missCount++;
            switch (missCount)
            {
                case 2:
                    bg.GetComponent<BackGround>().BGListForward();
                    break;
                case 4:
                    bg.GetComponent<BackGround>().BGListForward();
                    break;
                case 6:
                    bg.GetComponent<BackGround>().BGListForward();
                    break;
                default:
                    break;
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
            Debug.Log("ï«Ç™âìÇ¥Ç©Ç¡ÇΩ");
            foreach (var wall in list)
            {
                wall.GetComponent<WallMove>().WallBack();
            }

            cam.GetComponent<CameraController>().ZoomOut();

            missCount--;
            switch (missCount)
            {
                case 1:
                    bg.GetComponent<BackGround>().BGListBack();
                    break;
                case 3:
                    bg.GetComponent<BackGround>().BGListBack();
                    break;
                case 5:
                    bg.GetComponent<BackGround>().BGListBack();
                    break;
                default:
                    break;
            }
        }
    }
}
