using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSelector : MonoBehaviour
{
    public int scenenum;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            SceneManager.LoadScene(scenenum);
        }
    }
}
