using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject closeText;
    public GameObject player;

    public AudioSource doorSound;

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

    void Update()
    {
        isItLocked();
    }
    void DoorOpens()
    {
        Debug.Log("It Opens");
        door.SetBool("Open", true);
        doorSound.Play();
    }

    IEnumerator WaitAndShowText()
    {
        closeText.SetActive(true);
        yield return new WaitForSeconds(3);
        closeText.SetActive(false);
    }

    void isItLocked()
    {
        if (inReach && Input.GetButtonDown("Interact") && player.CompareTag("Has2Key"))
        {
            DoorOpens();
        }
        else if (inReach && Input.GetButtonDown("Interact"))
        {
            StartCoroutine(WaitAndShowText());
        }
    }
}