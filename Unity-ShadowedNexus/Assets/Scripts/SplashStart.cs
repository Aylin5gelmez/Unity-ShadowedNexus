using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashStart : MonoBehaviour
{
    public void ButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            

    }


}
