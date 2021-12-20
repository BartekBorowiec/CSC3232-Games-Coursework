using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TargetStartCountdown : MonoBehaviour
{

    private float currentTime = 0f;

    [SerializeField]
    public float StartingTime = 5f;
    [SerializeField]
    Text InfoTimer;

    public GameObject Info;

    public TargetSpawn targetSpawn; 

    public GameObject TargetTimer; 

    void Start()
    {
        currentTime = StartingTime; 
    }

    //a function for the countdown before the target game starts.
    //it will deactivate the info on the screen and activate the game timer. 
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        InfoTimer.text = currentTime.ToString("0"); 

        if (currentTime <= 0){
            gameObject.SetActive(false);
            Info.SetActive(false);


            targetSpawn.SpawnTarget();
            TargetTimer.SetActive(true);
        }
    }

    public void TimerReset(){
        currentTime = StartingTime; 
    }
}
