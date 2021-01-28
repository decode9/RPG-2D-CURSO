using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playSound(){
        audioSource.pitch = Random.Range(0.8f,1.1f);
        audioSource.Play();
    }

    public void stopSound(){
        audioSource.Stop();
    }
}
