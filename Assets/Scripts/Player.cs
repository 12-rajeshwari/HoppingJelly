using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;
    
    [SerializeField]
    private Rigidbody _RB;
    
    [SerializeField]
    private GameObject _capsulePrefab;
    
    private float _jumpingSpeed = 10f;
    
    // -- time delay to jump -- 
    private float _coolDownTime = 1f;
    private float _nextJumpTime = 0f;
    
    // -- time delay to fire capsule --
    private float _fireCoolDownTime = 0f;
    private float _nextFireTime = 0.5f;
    
    // Player Lives
    private int _lives = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        // Start position
        transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        
        // Firing Capsule at enemy 
        if (Input.GetKeyDown(KeyCode.E) && _nextFireTime < Time.time)
        {
            Instantiate(_capsulePrefab, transform.position + new Vector3(0f, 0.65f, 0f), Quaternion.identity);
            _nextFireTime = Time.time + _fireCoolDownTime;
        }
        
        Damage();
        
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
    
    // For reducing player's live
    public void Damage()
    {
        _lives --;
        Debug.Log("Damage"+ _lives);

        if(_lives == 0)
        {
            Debug.Log("Death");
        }

    }
}

