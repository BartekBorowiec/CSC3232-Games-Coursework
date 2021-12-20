using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;

    public GameObject Target;

    //spawns in a new target at a random location within the range size. 
    public void SpawnTarget(){
        Vector3 pos = (transform.localPosition + center) + new Vector3(Random.Range(-size.x / 2, size.x -2), Random.Range(-size.y / 2, size.y -2), Random.Range(-size.z / 2, size.z -2));

        Instantiate(Target, pos, Quaternion.identity);
    }

    //draws a red area for me to be able to see the spawn area when editing. 
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.localPosition + center, size);
    }

    void Update(){
        if (Input.GetKeyDown("k")){
            SpawnTarget(); 
        }
    }

}
