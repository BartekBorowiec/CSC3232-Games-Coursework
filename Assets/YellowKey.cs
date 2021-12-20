using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowKey : MonoBehaviour
{
    public static int YellowKeyCount; 
    public GameObject Player; 

    public bool gotYellowKey;

    void OnTriggerEnter(Collider collider){

        // increases the yellow key count and destorys the gameobject.
        //this is so we know the player got the key. 
        if (collider.gameObject == Player){
            YellowKeyCount = 1; 
            gotYellowKey = true; 
            Destroy (gameObject); 
        }
    }
}
