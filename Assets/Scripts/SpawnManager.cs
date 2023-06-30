using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    
    [SerializeField]
    private GameObject _enemyPrefab;
    
    //Set delay time to create new enemy
    private float _delay = 3f;
    
    //Check Player's is alive or dead
    private bool _alive = true;

    
    void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    
    //Check Player's is alive or dead
    public void OnPlayerDeath()
    {
        _alive = false;
    }

    // Spawning enemies until player is alive
    IEnumerator SpawnSystem()
    {
        while (_alive)
        {
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-8f, 8f), 10f, 0), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delay);
        }

        yield return null;
    }
}
