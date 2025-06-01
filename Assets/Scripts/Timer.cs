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

    [Header("Support Spawner")]
    [SerializeField]
    GameObject support;

    [Header("Obstruction Spawner")]
    [SerializeField]
    GameObject ob;

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

            support.GetComponent<SupportSpawner>().StopSpawning();
            ob.GetComponent<ObSpawner>().StopSpawning();
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


        if (second < 10)
        {
            ChangeSpawnInterval(0.6f, 0.9f);
        }
        else if (second < 20)
        {
            ChangeSpawnInterval(0.7f, 0.6f);
        }
        else if (second < 30)
        {
            ChangeSpawnInterval(0.8f, 0.5f);
        }
        else if (second < 40)
        {
            ChangeSpawnInterval(0.6f, 0.8f);
        }
        else if (second < 50)
        {
            ChangeSpawnInterval(0.5f, 1.0f);
        }
    }

    public void TimerStop()
    {
        timerstop = true;
    }

    public void ChangeSpawnInterval(float support, float ob)
    {
        this.support.GetComponent<SupportSpawner>().ChangeInterval(support);
        this.ob.GetComponent<ObSpawner>().ChangeInterval(ob);
    }
}
