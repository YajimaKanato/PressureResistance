using UnityEngine;
using System.Collections.Generic;

public class BackGround : MonoBehaviour
{
    [Header("BackGround")]
    [Tooltip("背景を設定してください")]
    [SerializeField]
    List<GameObject> list;

    public void BGListForward(int index1, int index2)
    {
        list[index1].gameObject.SetActive(false);
        list[index2].gameObject.SetActive(true);
    }

    public void BGListBack(int index1, int index2)
    {
        list[index2].gameObject.SetActive(false);
        list[index1].gameObject.SetActive(true);
    }
}
