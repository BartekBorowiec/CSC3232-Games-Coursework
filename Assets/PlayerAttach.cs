using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{

    public GameObject player;

    public PlayerMovement playermovement; 
    

    //when entering the trigger the object will be the players child thus making the player attach to it so it doesnt fall off the moving plaltform. 
    private void OnTriggerEnter(Collider other){

        if (other.gameObject == player){
            player.transform.parent = transform;
           playermovement.OnmovingPlatform();
        }
    }

    //when the player exits the platform range it will no longer be its child. 
    private void OnTriggerExit(Collider other){

        if (other.gameObject == player){
            player.transform.parent = null; 
            playermovement.OnmovingPlatform();
        }
    }

}
