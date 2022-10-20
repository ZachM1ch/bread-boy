using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveBread : MonoBehaviour
{
    public GameObject sliceyBoy;

    bool hasBred;

    public GameObject counter;
    public List<GameObject> counters;

    AudioSource myBoombox;
    AudioClip soundClip;
    public AudioClip[] soundClips;
    public AudioClip[] chirpClips;

    public float timer;
    float timerOG;
    bool timerOn;


    // Start is called before the first frame update
    void Start()
    {
        myBoombox = GetComponent<AudioSource>();

        foreach (GameObject c in GameObject.FindGameObjectsWithTag("Spot"))
        {
            counters.Add(c);
        }

        counter = counters[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerOn)
        {
            timerOG = Random.Range(0, 10) + 10;
            timerOn = true;
        }
        if (timer < timerOG)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timerOn = false;
            timer = 0;
            PlayRandomSound(chirpClips);
        }
        

    }



    public void OnCollisionEnter(Collision col)
    {
        GameObject slooce = col.gameObject;

        if (slooce.CompareTag("Slice"))
        {
            myBoombox.spatialBlend = 0;

            PlayRandomSound(soundClips);

            myBoombox.spatialBlend = 1;

            if (!hasBred)
            {
                counter.transform.localScale -= (new Vector3(1f, 1f, 1f));

                slooce.GetComponent<MeshRenderer>().enabled = false;
                Destroy(slooce, 1f);

                sliceyBoy.GetComponent<MeshRenderer>().enabled = true;

                hasBred = true;
                
            }

        }
    }

    public void OnTriggerEnter(Collider col)
    {
        GameObject slooce = col.gameObject;

        if (slooce.CompareTag("Slice"))
        {
            transform.GetComponent<BoxCollider>().enabled = false;

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
