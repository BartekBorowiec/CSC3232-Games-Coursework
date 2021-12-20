using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public Transform[] waypoints;

    public int speed;

    private int WayPointsIndex;

    private float distance; 



    //A script for enemyPatrol that I started put havent left it in the game. 

    //the enemy will go towards the first waypoint in the index at the start.
    void Start()
    {
        WayPointsIndex = 0;
        transform.LookAt(waypoints[WayPointsIndex].position);


    }

    //when the enemy reaches the range of the waypoint the waypoint index will increase thus making the player move towards the next waypoint. 
    void Update()
    {
        distance = Vector3.Distance(transform.position, waypoints[WayPointsIndex].position);

        if (distance < 2f){
            IndexIncrease();
        }
        EPatrol(); 
    }


    void EPatrol(){
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    //function to increase the waypoint and to reset it when the enemy reaches the final waypoint so that the enemy loops round them. 
    void IndexIncrease(){
        WayPointsIndex++;
        

        if (WayPointsIndex >= waypoints.Length){
            WayPointsIndex = 0;

        }
        transform.LookAt(waypoints[WayPointsIndex].position);
    }

}
