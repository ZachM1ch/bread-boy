using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBread : MonoBehaviour
{
    //Global Variables
    public GameObject prefabToSpawn;
    public GameObject otherPrefab;
    public GameObject loaf;
    int shotsFired;

    int launchVel = 250;

    Vector3 startPos;
    Vector3 midMov;

    AudioSource myBoombox;
    AudioClip soundClip;
    public AudioClip[] soundClips;


    // Start is called before the first frame update
    void Start()
    {
        myBoombox = GetComponent<AudioSource>();
        shotsFired = 0;
        startPos = loaf.transform.localPosition;
        midMov = new Vector3(0, 0, 0.101f);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (launchVel <= 2000)
            {
                if (launchVel > 400 && launchVel < 1001)
                {
                    if (launchVel % 150 == 0)
                    {
                        PlaySound(soundClips, 2);
                    }
                }
                else if (launchVel > 1001 && launchVel < 1501)
                {
                    if (launchVel % 150 == 0)
                    {
                        PlaySound(soundClips, 3);
                    }
                }
                else if (launchVel > 1501 && launchVel < 2001)
                {
                    if (launchVel % 150 == 0)
                    {
                        PlaySound(soundClips, 4);
                    }
                }

                launchVel += 5;

                
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (shotsFired < 9)
            {
                GameObject projectile = Instantiate(prefabToSpawn, transform.position, Quaternion.identity) as GameObject;

                PlaySound(soundClips, 0);

                projectile.GetComponent<Rigidbody>().AddForce(transform.up * 100);
                projectile.GetComponent<Rigidbody>().AddForce(transform.forward * launchVel);

                shotsFired++;
                loaf.transform.localPosition -= midMov;
                launchVel = 250;
            }
            
        }
        if (Input.GetKey(KeyCode.R))
        {
            ReloadBread();
        }

    }

    public void ReloadBread()
    {
        if (loaf.transform.localPosition.y < -0.600f || loaf.transform.localPosition.y > -0.800f)
        {
            myBoombox.volume = 0.3f;
            PlaySound(soundClips, 1);
            myBoombox.volume = 0.5f;
            loaf.transform.localPosition = startPos;
            shotsFired = 0;
        }
    }

    public void PlaySound(AudioClip[] ac, int num)
    {
        soundClip = ac[num];
        myBoombox.clip = soundClip;
        myBoombox.Play();
    }

}
