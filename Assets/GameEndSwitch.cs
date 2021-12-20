using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class GameEndSwitch : MonoBehaviour
{
    public KillsCounter killscounter; 

    public GameObject NotEnoughKills; 

    //A script to move the player onto the End Game screen


    //when the player collides with the door it will check whether the player has emliminated all of the enemies. 
    void OnTriggerEnter(Collider other){
        if(killscounter.KillsValue >= 14 && other.tag == "Player"){
            Cursor.lockState = CursorLockMode.None; 
            SceneManager.LoadScene("GameEnd");
        }else if (other.tag == "Player"){
            NotEnoughKills.SetActive(true);
            StartCoroutine(NotenoughKillsDelay(3)); 
        }
       
    }

    IEnumerator NotenoughKillsDelay(float time){

        yield return new WaitForSeconds(time);

        NotEnoughKills.SetActive(false); 
    }
}
