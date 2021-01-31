using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public bool gameOver = false;

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            SceneManager.LoadScene(0);
        }
    }
}
