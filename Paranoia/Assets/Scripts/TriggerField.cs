using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerField : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;

    public bool soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();   

        if(soundEffect)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            animator.SetTrigger("Trigger");

            if(soundEffect)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }

        }
    }
}
