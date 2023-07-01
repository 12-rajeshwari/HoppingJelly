using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _livestext;

    [SerializeField] 
    private Text _statustext;

    
    // DEFINE WIN & GAME OVER TEXT
    public void gameOver()
    {
        _statustext.text = "Game Over";
    }
    
    public void win()
    {
        _statustext.text = "You won :)";
    }
    public void UpdateLives(int health)
    {
        // UPDATE TEXT 
        _livestext.text = "lives: " + health;
        
    }
    
}
