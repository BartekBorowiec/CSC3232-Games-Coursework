using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class ScoreCounter : MonoBehaviour
{

    public int ScoreValue = 0;
    Text score; 

    public TargetSpawn targetSpawn; 


    public float endTime; 

    public GameObject GameTimer; 

    public GameObject WinText; 

    



    
    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        //updates the score if it changed. 
        score.text = "Score: " + ScoreValue; 

        //activates the wintext and deactivates the timer when the desired score is reached. 
        if(ScoreValue >= 30){
            WinText.SetActive(true);
            GameTimer.SetActive(false);

            StartCoroutine(GameWon(3));
            
        }
    }

    //function to increase the score counter and call the target spawn function to spawn in another target.
    public void ScoreIncrease(int Score){
        ScoreValue = ScoreValue + Score;
        if(ScoreValue < 30){
            targetSpawn.SpawnTarget();
        }
    }


    //a delay to change the scene to game3 when the score reaches the desired number. 
    IEnumerator GameWon(float time){
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("Game3");

    }

}
