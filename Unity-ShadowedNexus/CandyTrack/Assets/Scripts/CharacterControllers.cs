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

    private bool grounded;
    private bool started;
    private bool jumping;
    private void Awake()
    {
        _rigibody2D = GetComponent<Rigidbody2D>();//caching
        _animator = GetComponent<Animator>();//caching
       
    }
    private void Update()
    {

        { 
            if (started && grounded && Input.GetKeyDown("w"))
            {
                _animator.SetTrigger(name: "Jump");
                grounded = false;
                jumping = true;

            }
            else
            {
                started = true;
                _animator.SetBool(name: "GameStarted", value: true);
            }
            
         _animator.SetBool(name:"Grounded",value:true);

        }
    }
       
    
        private void FixedUpdate()
    {
        if (started && Input.GetKey("d"))
        {
            _rigibody2D.velocity= new Vector2(x:speed,_rigibody2D.velocity.y);
        }
        if(jumping)
        {
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


