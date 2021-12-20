using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2Switch : MonoBehaviour
{

    //function to load the next game scene when the player collides with it. 
    void OnTriggerEnter(Collider other){

        SceneManager.LoadScene("Game2");
    }
}
