using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    
    public GameObject ScoreUI;
    public GameObject InfoIU;
    public GameObject InfoTimerUI;
    public TargetStartCountdown targetstartcountdown;

    
    void Start(){
        ScoreUI.SetActive(false);
        InfoIU.SetActive(false);
        InfoTimerUI.SetActive(false);
    }

    //a function to activate all the ui for Game2 when the player goes into the game area. 
    //this also resets the start countdown. 
    void OnTriggerEnter (Collider Player){
        if(Player.gameObject.tag == "Player"){
            ScoreUI.SetActive(true);
            InfoIU.SetActive(true);
            InfoTimerUI.SetActive(true); 
            targetstartcountdown.TimerReset(); 

        }
    }
}
