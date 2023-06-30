using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _livestext;

    public void UpdateLives(int health)
    {
        // UPDATE TEXT 
        _livestext.text = "lives: " + health;
    }

}
