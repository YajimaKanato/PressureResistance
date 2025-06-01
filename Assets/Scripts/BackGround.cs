using UnityEngine;
using System.Collections.Generic;

public class BackGround : MonoBehaviour
{
    [Header("BackGround")]
    [Tooltip("�w�i��ݒ肵�Ă�������")]
    [SerializeField]
    List<GameObject> list;

    private int index = 0;
    
    public void BGListForward()
    {
        list[index].gameObject.SetActive(false);
        if (index + 1 < list.Count)
        {
            index++;
        }
        list[index].gameObject.SetActive(true);
    }

    public void BGListBack()
    {
        list[index].gameObject.SetActive(false);
        if (index - 1 >= 0)
        {
            index--;
        }
        list[index].gameObject.SetActive(true);
    }
}
