using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class Game3Restart : MonoBehaviour
{
    public PlayerMovement playermovement; 

    public GameObject PlayerDeathInfo;

    public GameObject DeathCamera; 


    //A script to restart game3 if the player dies. 
    void Update()
    {   

        // if the players health is 0 the death info will appear and the game will change camera. 
        if(playermovement.CurrentHealth <= 0){
            playermovement.PlayerDeath();
            PlayerDeathInfo.SetActive(true);
            DeathCamera.SetActive(true); 
            StartCoroutine(GameRestartDelay(5)); 
            
        }
    } 

    //A delay to restarting the level so it isnt immediately after the player dies. 

    IEnumerator GameRestartDelay(float time){

        yield return new WaitForSeconds(time);
        PlayerDeathInfo.SetActive(false);
        DeathCamera.SetActive(false);
        SceneManager.LoadScene("Game3");

    }

}
