using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void OnPress()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

}
