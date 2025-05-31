using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    [Header("Time Limit")]
    [Tooltip("�������ԁi�b���j���w�肵�Ă�������")]
    public float second = 60.0f;

    [Header("SetInactive Object")]
    [Tooltip("���Ԃ��؂ꂽ���ɔ�A�N�e�B�u�ɂ���I�u�W�F�N�g��ݒ肵�Ă�������")]
    [SerializeField]
    List<GameObject> listInactive;

    [Header("SetActive Object")]
    [Tooltip("���Ԃ��؂ꂽ���ɃA�N�e�B�u�ɂ���I�u�W�F�N�g��ݒ肵�Ă�������")]
    [SerializeField]
    List<GameObject> listActive;

    private Text text;
    private bool timerstop;
    void Start()
    {
        text = GetComponent<Text>();
        text.text = ((int)second).ToString("00") + ":" + ((second - (int)second) * 100).ToString("00");
    }

    // Update is called once per frame
    void Update()
    {
        if (second > 0)
        {
            second -= Time.deltaTime;
            text.text = ((int)second).ToString("00") + ":" + ((second - (int)second) * 100).ToString("00");
        }

        if (second <= 0.0f || timerstop)
        {
            //�^�C���A�b�v
            foreach (var go in listInactive)
            {
                go.SetActive(false);
            }

            foreach (var go in listActive)
            {
                go.SetActive(true);
            }

            this.gameObject.SetActive(false);
        }
    }

    public void TimerStop()
    {
        timerstop = true;
    }
}
