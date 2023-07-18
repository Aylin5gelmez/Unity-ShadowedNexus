using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstKey : MonoBehaviour
{
    public GameObject openText;
    public bool inReach;
    void Start()
    {
        inReach = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
            Debug.Log(other.gameObject.tag);
            other.gameObject.tag = other.gameObject.tag.Replace("Player", "Has1Key");//reachin tagina bakýyo playera bakmasý lazým
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject target in targets) {
                target.tag = "Has1Key"; 
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }
}
