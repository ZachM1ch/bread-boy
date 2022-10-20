using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyFunction : MonoBehaviour
{

    AudioSource myBoombox;
    AudioClip soundClip;
    public AudioClip[] soundClips;

    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        myBoombox = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Slice"))
        {
            PlaySound(soundClips, 0);
            particle.GetComponent<ParticleSystem>().Play();
        }
    }

    public void PlaySound(AudioClip[] ac, int num)
    {
        soundClip = ac[num];
        myBoombox.clip = soundClip;
        myBoombox.Play();
    }
}
