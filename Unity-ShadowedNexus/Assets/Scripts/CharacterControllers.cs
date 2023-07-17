using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UIElements;

public class CharacterControllers : MonoBehaviour
{
   
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForce = 50f;
    private Rigidbody2D _rigibody2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private bool grounded;
    private bool started;
    private bool jumping;
    private void Awake()
    {
         _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigibody2D = GetComponent<Rigidbody2D>();//caching
        _animator = GetComponent<Animator>();//caching
       grounded = true; 
    }
    private void Update()
    {
        if(Input.GetKeyDown("w"))
        { 
            if (started && grounded )
            {
                
                _animator.SetTrigger(name: "Jump");
                grounded = false;
                jumping =true;
            }

            else
            {
                started = true;
                _animator.SetBool(name: "GameStarted", value: true);
            }
            _animator.SetBool(name: "Grounded", value: true);
        }
    }

    private void FixedUpdate()
    {
        if (started && Input.GetKey("d"))
        {
            _rigibody2D.velocity= new Vector2(x:speed,_rigibody2D.velocity.y);
            _spriteRenderer.flipX = false;
        }
        else if (started &&Input.GetKey("a"))
        {
            _rigibody2D.velocity = new Vector2(x: (-1)*speed, _rigibody2D.velocity.y);
            _spriteRenderer.flipX = true;
        }
        else if(jumping)
        {   _spriteRenderer.flipX = false;
            //Debug.Log(message: "jumping");
            _rigibody2D.AddForce(new Vector2(x:0f, y:jumpForce));   
            jumping = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.CompareTag("Ground") )
       {
            grounded = true;
       }
    }

}


