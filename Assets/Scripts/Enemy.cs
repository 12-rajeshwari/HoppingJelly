using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField]
    private float _enemySpeed = 2f;

   
    // Update is called once per frame
    void Update()
    {
        // MOVEMENT of Enemy
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        // TRANSPORT BACK TO START
        if(transform.position.y < -4.5)
        {
            transform.position = new Vector3(Random.Range(-10f, 15f), 40f, 0f);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Capsule"))
        {
            // Destory both Capsule and Enemy
            Destroy(this.gameObject);
            Destroy(other.gameObject);

        }

        // Damage Player live
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            other.GetComponent<Player>().Damage();
            
        }
    }
    
}
