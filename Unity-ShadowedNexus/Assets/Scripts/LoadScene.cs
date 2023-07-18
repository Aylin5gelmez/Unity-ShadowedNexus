using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Has1Key"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log(other.gameObject.tag);
            other.gameObject.tag = other.gameObject.tag.Replace("Has1Key", "Has2Key");
            Debug.Log(other.gameObject.tag);

        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entered elif");
            SceneManager.LoadScene("EntryScene");
            Debug.Log(other.gameObject.tag);
            other.gameObject.tag = other.gameObject.tag.Replace("Player", "Has1Key");
            Debug.Log(other.gameObject.tag);

        }
        else
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
