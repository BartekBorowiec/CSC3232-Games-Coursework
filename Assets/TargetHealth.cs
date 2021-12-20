using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealth : MonoBehaviour
{
    public float targetHealth;

    public ScoreCounter scoreCounter; 

    private int targetScore = 1; 

    [SerializeField] ParticleSystem particle = null;



    //functon to deal damage to the target and destory it if the health is 0. 
    public void TakeDamage(float Damage){
        targetHealth -= Damage;
        

        if (targetHealth <= 0f){
            particle.Play(); 
            Destroy(gameObject);
            scoreCounter.ScoreIncrease(targetScore);  
        }
    }


}
