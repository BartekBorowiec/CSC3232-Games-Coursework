using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform TeleportPosition;
    public Transform TeleportPosition2;
    public Transform TeleportPosition3;
    public Transform TeleportPosition4;

    public RedKey redkey; 
    public YellowKey yellowkey; 

    public GameObject Player;
    
    public PlayerMovement playermovement; 

    
    //A function that teleports the player to specific points.
    //this is used in game1 and the player will be teleported to different checkpoints based on how far they have gotten in the level based on things like what keys the player has obtained. 
    
    void OnTriggerEnter(Collider other)
    {
        playermovement.checkTeleport = true;
        playermovement.FallDistance = 0;
        playermovement.LastPositionY = 0;
        if (playermovement.gravity == -11f){
            Player.transform.position = TeleportPosition4.transform.position;
        }else if(redkey.gotRedKey && yellowkey.gotYellowKey){
            Player.transform.position = TeleportPosition3.transform.position;
        }else if (redkey.gotRedKey){
            Player.transform.position = TeleportPosition2.transform.position;
        }else{
            Player.transform.position = TeleportPosition.transform.position;
        }
        
        
    }

    
    
}
