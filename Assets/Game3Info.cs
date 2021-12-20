using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game3Info : MonoBehaviour
{
    public GameObject Info; 


    //A script to delete the info that appears on the players screen when entering game3 after a delay. 
    void Start()
    {
        StartCoroutine(InfoDelay(5)); 
    }


    IEnumerator InfoDelay(float time){

        yield return new WaitForSeconds(time);
        Info.SetActive(false); 
    }
}
