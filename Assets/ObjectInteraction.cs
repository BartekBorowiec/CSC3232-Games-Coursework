using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{

    [SerializeField]
    private float forceMagnitude; 
    

    private void OnControllerColliderHit(ControllerColliderHit Hit){
        Rigidbody rigidbody = Hit.collider.attachedRigidbody;

        //applies force to the gameObject when the player collides with it which makes the object move in the given direction. 
        if (rigidbody != null){
            Vector3 forceDirection = Hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();
            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse); 
        }
    }

}
