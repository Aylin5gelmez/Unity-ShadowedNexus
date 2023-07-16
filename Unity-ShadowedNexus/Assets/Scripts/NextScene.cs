using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public GameObject Button;
    public bool active = true;
    private Scene _scene;
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }
    void StartGame()
    {
        if(active)
        {
            Button.SetActive(false);
            active= false;
            SceneManager.LoadScene(_scene.buildIndex + 1);
        }
        else if(!active)
        {
            Button.SetActive(true);
            active= true;
        }
    }
}
