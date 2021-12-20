using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillsCounter : MonoBehaviour
{

    public int KillsValue;
    Text kills; 

    void Start()
    {
        kills = GetComponent<Text>();
    }

    //updates the kills text to the killvalue.
    void Update()
    {
        kills.text = "Kills: " + KillsValue;

        
    }

    //function to be called to increase the kill value when the player kills an enemy. 

    public void KillsIncrease(){
        KillsValue++; 
    }
}
