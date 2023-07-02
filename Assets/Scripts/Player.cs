using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;
    private float _jumpingSpeed = 12f;

    [SerializeField] 
    private Rigidbody _RB;

    [SerializeField] 
    private GameObject _capsulePrefab;

    [SerializeField] 
    private GameObject _spawnManager;

    [SerializeField]
    private UI_Manager _uiManager;

    // -- time delay to jump -- 
    private float _coolDownTime = 0.5f;
    private float _nextJumpTime = 0f;

    // -- time delay to fire capsule --
    private float _fireCoolDownTime = 0f;
    private float _nextFireTime = 0.5f;

    // Player Lives and change color of player when it collides with enemy or die
    private int _lives = 3;
    private float _colorChannel = 0.5f;
    private MaterialPropertyBlock _mpb;

    // Start is called before the first frame update
    void Start()
    {
        // Start position
        transform.position = new Vector3(0f, 0f, 0f);


        // SET MATERIAL
        if (_mpb == null)
        {
            _mpb = new MaterialPropertyBlock();
            _mpb.Clear();
        }

        // UPDATE LIVES
        _uiManager.UpdateLives(_lives);

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
    }

    // For reducing player's live
    public void Damage()
    {

        // Update Player's live
        _lives--;
        _uiManager.UpdateLives(_lives);
        Debug.Log("Damage -1  Lives: " + _lives);

        // CHANGE MATERIAL
        _colorChannel += 0.2f;
        _mpb.SetColor("_Color", new Color(_colorChannel, _colorChannel, 0, 0.5f));
        this.GetComponent<Renderer>().SetPropertyBlock(_mpb);

        // Check game over condition
        if (_lives == 0)
        {
            Debug.Log("Game Over");

            // DELETE ENEMYS IN HIERACHY
            foreach (Transform child in _spawnManager.transform)
            {
                Destroy(child.gameObject);
            }


            // STOP SPAWNING ENEMIES AND DESTROY
            if (_spawnManager != null)
            {
                _spawnManager.GetComponent<SpawnManager>().OnPlayerDeath();
                Destroy(this.gameObject);
            }
            else
            {
                Debug.LogError("SpawnManager not assigned.");
            }
            
        }
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
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0f, 2f, 0f);
        }
    }
 }

