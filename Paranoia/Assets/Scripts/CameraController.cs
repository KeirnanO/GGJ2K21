using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerObject;

    public Transform pivot;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, pivot.position + offset, 0.1f);
    }

    public void CameraFix()
    {
        transform.parent = playerObject.transform;
        enabled = true;
        GetComponent<MouseLook>().enabled = true;
    }

}
