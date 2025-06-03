using UnityEngine;
using System.Collections.Generic;

public class BGMManager : MonoBehaviour
{
    [Header("BGM")]
    [Tooltip("BGMÇê›íËÇµÇƒÇ≠ÇæÇ≥Ç¢")]
    [SerializeField]
    AudioClip sound;


    private AudioSource[] audioSource = new AudioSource[20];

    private static int index = 0;
    public static int Index { set { index = value; } }

    public static BGMManager instance;

    private void Awake()
    {
        audioSourceSet();
        if (instance == null)//ÉVÉìÉOÉãÉgÉì
        {
            instance = this;
            
            //SoundChange(sound);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void audioSourceSet()
    {
        Debug.Log("audioSet");
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    AudioSource GetUnusedAudioSource()
    {
        Debug.Log("getUnused");
        foreach (var audiosource in audioSource)
        {
            if (audiosource.isPlaying == false)
            {
                return audiosource;
            }
        }
        return null;
    }

    public void SoundChange(AudioClip clip)
    {
        var audiosource = GetUnusedAudioSource();
        if (audiosource == null)
        {
            return;
        }
        audiosource.clip = clip;
        audiosource.Play();
    }
}
