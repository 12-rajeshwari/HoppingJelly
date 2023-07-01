using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Script : MonoBehaviour
{
    [SerializeField]
    private UI_Manager _uiManager;

    [SerializeField]
    private SpawnManager _spawnManager;
    

    // DEFINE WINNING STATE 
    private void OnTriggerEnter(Collider other)
    {
        // IF PLAYER SELECTS THE GOLDEN COIN ...
        if (other.CompareTag("Player"))
        {
            _spawnManager.onPlayerWin();
            _uiManager.win();
            Destroy(this.gameObject);
        }
    }
}
