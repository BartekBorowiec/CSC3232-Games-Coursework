using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : MonoBehaviour
{
    public static int RedKeyCount; 
    public GameObject Player; 

    public bool gotRedKey = false; 

    void OnTriggerEnter(Collider collider){
        //changes the red key count to 1 when the player touches it and deletes the gameobject to make it seem that the player picked up the key. 
        if (collider.gameObject == Player){
            RedKeyCount = 1; 
            gotRedKey = true; 
            Destroy (gameObject); 
            
        }
    }
}
