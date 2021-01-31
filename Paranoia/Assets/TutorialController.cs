using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{

    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            animator.SetTrigger("Trigger");

            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
