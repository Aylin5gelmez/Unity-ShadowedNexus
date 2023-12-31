using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BowlMovement : MonoBehaviour
{
    public float movementSpeed = 30f;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public int targetScore = 500;
    public GameObject panel;

    void Start()
    {
        scoreText.text = "Score: " + score;
        UpdateScoreText();
    }

    void Update()
    {
        float xMovement = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * xMovement);
        float bowlRange = GetComponent<SpriteRenderer>().bounds.extents.x;
        float screenRange = Camera.main.aspect * Camera.main.orthographicSize;
        float rangeX = Mathf.Clamp(transform.position.x, -screenRange + bowlRange, screenRange - bowlRange);
        transform.position = new Vector3(rangeX, transform.position.y, transform.position.z);
        UpdateScoreText();
        if (score >= targetScore)
        {
            LoadNextScene();
        }
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            score += 50;
            Destroy(collision.gameObject);
            UpdateScoreText();
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {
            score -= 20;
            Destroy(collision.gameObject);
            UpdateScoreText();
        }
        
        if (score >= targetScore)
        {
            UpdateScoreText();
            Time.timeScale = 0.0f;
            panel.SetActive(true);
            
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
