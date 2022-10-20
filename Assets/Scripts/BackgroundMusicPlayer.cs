using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    //Los Globos
    //audio functionality:
    public AudioSource myBoombox; //this is what will play a clip.
    public AudioClip[] soundClips; //we will assign these in the Inspector.
    public AudioClip soundClip;

    public bool bgmOn = true;
    public bool bgm2On = true;

    public int index;

    public GameObject endScreen;

    // Start is called before the first frame update
    void Start()
    {
        myBoombox = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J))
        {
            endScreen.SetActive(true);
        }

        if (bgmOn)
        {
            PlaySound(index);
            bgmOn = false;
        }
        if(endScreen.activeInHierarchy && bgm2On)
        {
            PlaySound(2);
            bgm2On = false;
        }
        
    }

    public void PlaySound(int num)
    {
        soundClip = soundClips[num];
        myBoombox.clip = soundClip;
        myBoombox.Play();
    }

    public void setIndex(int num)
    {
        index = num;
    }
}
