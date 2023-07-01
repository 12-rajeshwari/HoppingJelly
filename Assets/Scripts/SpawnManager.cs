using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    // LIST - containing all prefabs we want to spawn randomly
    [SerializeField] 
    private GameObject[] CoffeeShopItems;
    
    
    [SerializeField]
    private GameObject _enemyPrefab;
    
    //Set delay time to create new enemy
    private float _delay = 2f;
    
    //Check Player's is alive or dead
    private bool _alive = true;
    
    //Check Player's won or loose
    private bool _win = false;
    
    
    [SerializeField]
    private UI_Manager _uiManager;
    void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    // RETURNS the number of prefabs added to the CoffeeShop_Items list 
    private int GetRandomNumber()
    {
        System.Random random = new System.Random();
        int randomNumber = random.Next(0, CoffeeShopItems.Length);
        return randomNumber;
    }
    
    
    //Check Player's is alive or dead and Player's status
    public void OnPlayerDeath()
    {
        _alive = false;
        _uiManager.gameOver();
    }

    public void onPlayerWin()
    {
        _win = true; 
    }
    
    
    // Spawning enemies until player is alive
    IEnumerator SpawnSystem()
    {
        while (_alive && !_win)
        {
            // RANDOMLY ASSIGN ENEMYPREFAB + INSTANTIATE 
            _enemyPrefab = CoffeeShopItems[GetRandomNumber()];
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-10f, 15f), 35f, 0), Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delay);
        }

        yield return null;
    }
}
