using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSoundController : MonoBehaviour
{

    public AudioClip[] Sounds;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Speak());
    }

    IEnumerator Speak()
    {
        while(true)
        {
            yield return new WaitForSeconds(5f);


            int ran = Random.Range(0, Sounds.Length);
            audioSource.PlayOneShot(Sounds[ran]);
        }
    }
}
