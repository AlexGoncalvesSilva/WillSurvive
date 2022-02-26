using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip backgroundSound;
    public AudioClip door_closed;
    public AudioClip door_open;
    public AudioClip frizedSlime;
    public AudioClip hit_collision;
    public AudioClip hit_gosma;

    private AudioSource audioSource;

    public static AudioController current;

    // Start is called before the first frame update
    void Start()
    {
       current = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
