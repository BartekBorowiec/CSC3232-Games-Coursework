using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TargetGameTimer : MonoBehaviour
{

    public float CurrentTime = 0f;

    [SerializeField]
    public float StartingTime = 100f;

    [SerializeField]
    Text TargetTimer;

    public ScoreCounter scorecounter; 

    public GameObject LoseText; 

    void Start()
    {
        //sets the time to the starting time. 
        CurrentTime = StartingTime; 
    }

    void Update()
    {
        //updates the current time by decreasing the number by 1 every second. 
        CurrentTime -= 1 * Time.deltaTime;
        //sets the text to the time. 
        TargetTimer.text = CurrentTime.ToString("0");

        //activates the lose text if the timer ends before the desired score is reached. 
        //also restarts the level. 
        if (CurrentTime <= 0 && scorecounter.ScoreValue != 30){
            LoseText.SetActive(true);
            TargetTimer.text = ""; 
            StartCoroutine(RestartLevel(3)); 
            
        }

    }
        //delay on the level restart. 
        IEnumerator RestartLevel(float Delay){
            yield return new WaitForSeconds(Delay);

            SceneManager.LoadScene("Game2"); 
        }
    


}
