using UnityEngine;
using System.Collections.Generic;

public class BGMManager : MonoBehaviour
{
    [Header("BGM")]
    [Tooltip("BGM‚ğİ’è‚µ‚Ä‚­‚¾‚³‚¢")]
    [SerializeField]
    List<AudioClip> sound;

    private static int index = 0;
    public static int Index { set { index = value; } }

    public static BGMManager instance;

    private void Start()
    {
        if (instance == null)//ƒVƒ“ƒOƒ‹ƒgƒ“
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SoundChange();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SoundChange()
    {
        this.GetComponent<AudioSource>().clip = sound[index];
        this.GetComponent<AudioSource>().Play();
    }
}
