using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
        {
            animator.enabled = false;


            if(gameObject.tag.Equals("Player"))
                FindObjectOfType<CameraController>().CameraFix();

            if (gameObject.tag.Equals("Lantern"))
                GetComponent<SphereCollider>().enabled = true;
        }
    }
}
