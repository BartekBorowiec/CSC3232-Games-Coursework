using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    public GameObject Player; 

    public GameObject leftpanel;
    public GameObject rightpanel;
    
    
    void OnTriggerEnter(Collider collider){
        //checks whether the player has the red key and if so then it will delete the object which means the player can go through the door. 
        if(collider.gameObject == Player && RedKey.RedKeyCount == 1){
            RedKey.RedKeyCount = 0;
            Destroy(leftpanel);
            Destroy(rightpanel); 
            Destroy(gameObject); 
        }
    }

}
