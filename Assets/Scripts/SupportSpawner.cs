using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
class SupportData
{
    [Header("Support Prefab")]
    [Tooltip("��������v���n�u��ݒ肵�Ă�������")]
    public GameObject prefab;

    [Range(0.0f, 1.0f)]
    [Tooltip("�v���n�u�̏o���m��")]
    public float weight = 1.0f;
}
public class SupportSpawner : MonoBehaviour
{
    [Header("Prefab List with Probability")]
    [Tooltip("��������v���n�u�Ƃ��̊m����ݒ肵�Ă�������")]
    [SerializeField]
    List<SupportData> list = new List<SupportData>();

    [Header("Spawn Settings")]
    [Tooltip("�����Ԋu")]
    [SerializeField]
    float spawnInterval = 1.0f;

    Coroutine coroutine;

    private void Start()
    {
        coroutine = StartCoroutine(SpawnRandom());
    }

    IEnumerator SpawnRandom()
    {
        while (true)
        {
            Spawning();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Spawning()
    {
        if (list.Count == 0 || list == null)
        {
            Debug.Log("���X�g����ł�");
            return;
        }

        float totalWeight = 0.0f;
        foreach (var item in list)
        {
            totalWeight += item.weight;
        }

        float nowWeight = 0.0f;
        float rand = Random.Range(0.0f, totalWeight);
        foreach (var item in list)
        {
            nowWeight += item.weight;
            if (rand <= nowWeight)
            {
                Instantiate(item.prefab, transform.position, Quaternion.identity);
                break;
            }
        }
    }

    void StopSpawning()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}
