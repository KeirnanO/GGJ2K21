using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternSoundController : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] clips;

    int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(Creak());
    }

    IEnumerator Creak()
    {
        while (true)
        {
            audioSource.PlayOneShot(clips[num]);

            num++;
            num %= 2;

            yield return new WaitForSeconds(0.5f);
        }
    }
}
