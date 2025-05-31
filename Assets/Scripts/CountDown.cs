using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private Text text;

    [Header("SetActive Object")]
    [Tooltip("カウントダウン後にアクティブにするオブジェクトを設定してください")]
    [SerializeField]
    List<GameObject> list;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(CountDownCoroutine());
    }

    IEnumerator CountDownCoroutine()
    {
        text.text = "3";
        yield return new WaitForSeconds(1f);
        text.text = "2";
        yield return new WaitForSeconds(1f);
        text.text = "1";
        yield return new WaitForSeconds(1f);
        text.text = "Start!";
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);

        foreach(var go in list)
        {
            go.SetActive(true);
        }
    }
}
