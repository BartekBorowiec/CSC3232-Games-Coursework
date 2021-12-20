using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDoor : MonoBehaviour
{
    public GameObject Player; 

    public GameObject leftpanel;
    public GameObject rightpanel;
    
    //the door will delete when the player has the yellow key. 
    void OnTriggerEnter(Collider collider){
        if(collider.gameObject == Player && YellowKey.YellowKeyCount == 1){
            YellowKey.YellowKeyCount = 0;
            Destroy(leftpanel);
            Destroy(rightpanel); 
            Destroy(gameObject); 
        }
    }
}
