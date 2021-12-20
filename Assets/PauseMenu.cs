using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class PauseMenu : MonoBehaviour
{
    public bool GamePause = false;
    
    public GameObject PauseUI;

    //when the player presses on the esc key the pause function will be called if it isnt paused already then it will resume. 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GamePause){
                Resume();
            }else{
                Pause();
            }
        }
    }

    //resumes the time and gets rid of the pause ui and locks the mouse. 
    public void Resume(){
        
        PauseUI.SetActive(false);
        Time.timeScale = 1f; 
        GamePause = false; 
        Cursor.lockState = CursorLockMode.Locked; 
    }

    //pauses the time so the game is paused. 
    void Pause(){
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true; 
        Cursor.lockState = CursorLockMode.None; 

    }

    //quits the game when the quit button is clicked. 
    public void QuitGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }


}
