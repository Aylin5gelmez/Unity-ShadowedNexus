using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    Vector3 target = new Vector3(-34.6f, 1.08f, 11.95f);
        
    // Update is called once per frame
    void Update()
    {
        GotoNextScene();

    }

    void GotoNextScene()
    {
        if (Vector3.Distance(transform.position,target)<=1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
