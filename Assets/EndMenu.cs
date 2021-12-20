using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EndMenu : MonoBehaviour
{
    //unlocks the cursor so the player can interact with the menu.
    void start(){
        Cursor.lockState = CursorLockMode.None;
    }
    //function to load the menu scene
    public void Menu(){
        SceneManager.LoadScene("Menu");
    }
    //function to quit the game completely.
    public void QuitGame(){
        Application.Quit();
    }
}
