using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musicCollection;
    public static MusicManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (!instance) { instance = this; return; }
        Destroy(gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        //PlayMusic(0);
    }

    public void PlayMusic(int index)
    {
        audioSource.clip = musicCollection[index];
        audioSource.Play();
    }
}
