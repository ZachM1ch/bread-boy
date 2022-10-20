using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSounds : MonoBehaviour
{

    AudioSource myBoombox;
    AudioClip soundClip;
    public AudioClip[] grassClips;
    public AudioClip[] stoneClips;

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
        if (other.transform.CompareTag("Rock"))
        {
            PlayRandomSound(stoneClips);
        }
        if (other.transform.CompareTag("Floor"))
        {
            PlayRandomSound(grassClips);
        }
    }

    public void PlayRandomSound(AudioClip[] ac)
    {
        int rand = Random.Range(0, ac.Length);
        soundClip = ac[rand];
        myBoombox.clip = soundClip;
        myBoombox.Play();
    }

}
