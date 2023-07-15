using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitPrefab; 
    public GameObject bombPrefab;
    public float startHeight= 10f;
    public float minSpeed = 0.4f;
    public float maxSpeed = 1.2f;
    public float dropDown = 0.4f;
    public float speedIncrease = 0.3f;
    public float speedIncreaseTime = 2.2f;
    public float objectIncreaseTime = 2.2f;
    public int maxObjectAmount = 2000;

    private float screenRange;
    private int objectAmount = 5;

    void Start()
    {
        screenRange = Camera.main.aspect * Camera.main.orthographicSize;
        InvokeRepeating("CreateObject", dropDown, dropDown);
        InvokeRepeating("IncreaseSpeed", speedIncreaseTime, speedIncreaseTime);
        InvokeRepeating("IncreaseObject", objectIncreaseTime, objectIncreaseTime);
    }

    void CreateObject()
    {
        if (objectAmount <= maxObjectAmount)
        {
            GameObject objectPrefab;

            
            float randomNumber = Random.Range(0f, 1f);
            if (randomNumber < 0.7f) 
            {
                objectPrefab = fruitPrefab[Random.Range(0, fruitPrefab.Length)];
            }
            else 
            {
                objectPrefab = bombPrefab;
            }

            
            Vector3 objectLocation = new Vector3(Random.Range(-screenRange, screenRange), startHeight, -0.01f);
            GameObject fruibo = Instantiate(objectPrefab, objectLocation, Quaternion.identity);

            
            float dropSpeed = Random.Range(minSpeed, maxSpeed);
            fruibo.GetComponent<Rigidbody2D>().velocity = Vector2.down * dropSpeed;

            objectAmount++;
        }
    }

    void IncreaseSpeed()
    {
        minSpeed += speedIncrease;
        maxSpeed += speedIncrease;
    }

    void IncreaseObject()
    {

        objectAmount++;
        if (objectAmount <= maxObjectAmount)
        {
            objectAmount++;
        }
    }

}
