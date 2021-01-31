using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterSound : MonoBehaviour
{

    public AudioClip sound;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            audioSource.PlayOneShot(sound);

            Destroy(gameObject, 3f);
        }
    }
}
