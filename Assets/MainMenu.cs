using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //loads the first level when the button is clicked.
    public void PlayGame(){
        SceneManager.LoadScene("Game");
    }

    //quits the game when the Quit button is clicked. 
    public void QuitGame(){
        Application.Quit();
    }
}
