using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    
    [SerializeField]
    private Rigidbody _RB;
    
    private float _jumpingSpeed = 10f;
    
    // -- time delay -- 
    private float _coolDownTime = 1f;
    private float _nextJumpTime = 0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        // Horizontal Input is used to control movement of player (to move right or left)
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);  
        
        // Jumping Movement : Press "Space" to jump
        if (Input.GetKeyDown("space") && _nextJumpTime < Time.time)
        {
            _RB.velocity += new Vector3(0f, _jumpingSpeed, 0f);
            _nextJumpTime = Time.time + _coolDownTime;
        }
        
        // TELEPORT - if player is falls, teleport him back to a start position
        if(transform.position.y < -10)
        {
            transform.position = new Vector3(0f, 2f, 0f);
        }
        
    }
}

