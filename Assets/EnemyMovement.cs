using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Player;
    public float Distance; 
    public float pointDistance;
    public bool inRange;
    public NavMeshAgent agent;

    public float EnemyHealth = 5f;

    public PlayerMovement playermovement; 
    public bool canDamage = true; 

    public float Range = 10; 

    public KillsCounter kills; 

    

    Vector3 StartPosition;

    public LayerMask whatIsGround; 

    
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float PointRange;

    public bool OutOfTime = false; 
    public bool startTimer = false;


    void Start(){
        StartPosition = this.transform.position;
        agent = GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {
        //a check to see whether the player is in range of the enemy or not. 
        Distance = Vector3.Distance(Player.transform.position, this.transform.position);
        if(Distance <= Range){
            inRange = true;

        }else{
            inRange = false; 
        }
        
        //if statements to check what state the enemy ai should be in. This depends on the distance that the enemy is to the player.

        if(!inRange && !startTimer){
            Patroling();
        }
        if(!inRange && startTimer && walkPointSet){
            agent.SetDestination(walkPoint); 
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //this is to reset the walkpoint if the player is out of time or within the range to the walkpoint
        //This way the enemy will never get stuck forever because they cant reach the walkpoint for some reason. 
        if(distanceToWalkPoint.magnitude < 1f || OutOfTime){
            walkPointSet = false;
            OutOfTime = false; 
            
            
        }
        if (inRange){
            ChasePlayer();
        }
        if ((Distance < 1.5) && canDamage){
            AttackPlayer();
        }

    }


    //function for the enemy to walk towards the new walkpoint set. 
    //due to the navmesh the enemy will not try and walk through objects in the scene.
    //in the upstairs bit of level 3 there are shootable crates which will dynamically change the navmesh so that the enemy can walk over the area where the crates used to be
    //if the player does shoot the crate
    private void Patroling(){
        if(!walkPointSet) FindWalkPoint(); 
        if(walkPointSet){
            
            agent.SetDestination(walkPoint); 
            startTimer = true;
        }
        
    
        if(startTimer){
            StartCoroutine(WalkTimer(Random.Range(2, 5)));
        }
        
    }


    //function to find the the next walk point for the ai enemy at random. 
    private void FindWalkPoint(){
        float RandomZ = Random.Range(-PointRange, PointRange);
        float RandomX = Random.Range(-PointRange, PointRange);

        walkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)){
            walkPointSet = true; 
        }
    }
    //enemy will move towards the player when the function is called. 
    private void ChasePlayer(){
        agent.SetDestination(Player.transform.position);
    }

    //function that is called when the player is in the attack range of the enemy.
    //This will deal damage to the player. but has a delay so its not fast hits. 
    private void AttackPlayer(){
        playermovement.TakeDamage(10); 
        canDamage = false;
        StartCoroutine(DamageDelay(1)); 
    }

    //function to delay the damage in between damages to not spam the damage. 
    IEnumerator DamageDelay(float Time){
        yield return new WaitForSeconds(Time);
        canDamage = true; 
    }

    IEnumerator WalkTimer(float Time){
        yield return new WaitForSeconds(Time);
        OutOfTime = true;
        startTimer = false; 
    }



    //function to deal damage to the enemy which is called from a different script. 
    public void TakeDamage(float Damage){
        EnemyHealth -= Damage;

        if (EnemyHealth <= 0f){
            kills.KillsIncrease(); 
            Destroy(gameObject);
        }
    }
}
