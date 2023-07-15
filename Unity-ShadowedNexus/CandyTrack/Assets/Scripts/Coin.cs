using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] public int candy = 0;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private AudioClip clickSound;

    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if(other.gameObject.CompareTag("Collectible"))
        {

            Candy.candy++;
            AudioSource.PlayClipAtPoint(clickSound,other.transform.position);
            Destroy(other.gameObject);
            _text.text =Candy.candy.ToString();
        }

    }
}
