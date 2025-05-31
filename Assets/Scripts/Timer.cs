using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    [Header("Time Limit")]
    [Tooltip("制限時間（秒数）を指定してください")]
    public float second = 60.0f;

    [Header("SetInactive Object")]
    [Tooltip("時間が切れた時に非アクティブにするオブジェクトを設定してください")]
    [SerializeField]
    List<GameObject> listInactive;

    [Header("SetActive Object")]
    [Tooltip("時間が切れた時にアクティブにするオブジェクトを設定してください")]
    [SerializeField]
    List<GameObject> listActive;

    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        text.text = ((int)second).ToString("00") + ":" + ((second - (int)second) * 100).ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        if (second > 0 && TimerStart())
        {
            second -= Time.deltaTime;
            text.text = ((int)second).ToString("00") + ":" + ((second - (int)second) * 100).ToString("00");
        }

        if (second <= 0.0f || TimerStop())
        {
            //タイムアップ
            foreach (var go in listInactive)
            {
                go.SetActive(false);
            }

            foreach (var go in listActive)
            {
                go.SetActive(true);
            }
        }
    }

    public bool TimerStart()
    {
        return true;
    }

    public bool TimerStop()
    {
        return false;
    }
}
