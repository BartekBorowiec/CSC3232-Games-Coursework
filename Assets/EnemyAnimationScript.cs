using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationScript : MonoBehaviour
{

    private Animator anim;

    private Vector3 lastPosition;
    private bool ismoving; 
   
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();


    }

    void Update()
    {
        

        if(lastPosition != gameObject.transform.position){
            ismoving = true; 
        }else{
            ismoving = false; 
        }
        lastPosition = gameObject.transform.position;

        if (ismoving) {
			anim.SetInteger ("AnimationPar", 1);
		}else {
			anim.SetInteger ("AnimationPar", 0);
		}

    }
}
