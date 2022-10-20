using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadSounds : MonoBehaviour
{

    AudioSource myBoombox;
    AudioClip soundClip;
    public AudioClip[] soundClips;

    // Start is called before the first frame update
    void Start()
    {
        myBoombox = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Floor") || other.transform.CompareTag("Rock"))
        {
            PlaySound(soundClips, 0);
        }
    }


    public void PlaySound(AudioClip[] ac, int num)
    {
        soundClip = ac[num];
        myBoombox.clip = soundClip;
        myBoombox.Play();
    }
}
