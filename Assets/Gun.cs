using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class Gun : MonoBehaviour
{
    [SerializeField]
    private Camera PlayerCamera; 

    [SerializeField]
    private LayerMask EnemyLayer;

    [SerializeField]
    private LayerMask EnemyHeadLayer;

    [SerializeField]
    private LayerMask GroundLayer;

    [SerializeField]
    private LayerMask CrateLayer;
    
    [SerializeField]
    private float Damage;

    [SerializeField]
    private float HeadshotDamage;

    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private Transform AttackPoint;

    public GameObject Head; 

    public PauseMenu pausemenu; 

    private bool PulledTrigger = false; 

    public Transform laserOrigin;
    public float laserDuration = 0.05f; 
    LineRenderer laserLine; 


    void Awake(){
        laserLine = GetComponent<LineRenderer>(); 
    }
    

    void Update(){

        //creates a ray when the player clicks the mousebutton
        //the ray will go in the direction where the player is looking so at the center of the crosshair.
        if(Input.GetMouseButtonDown(0) && !PulledTrigger && pausemenu.GamePause == false){
            Ray gunshot = new Ray(PlayerCamera.transform.position, PlayerCamera.transform.forward);
            Vector3 Ray = PlayerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f,0)); 

            SoundManager.PlaySound("laser"); 
            
            laserLine.SetPosition(0, laserOrigin.position); 


            //this checks whether the ray has hit an object with a specific layer to execute the code. 
            if(Physics.Raycast(gunshot, out RaycastHit hitInfo, 100f, EnemyLayer)){

                
                //in game2 it will call the TakeDamage() function when it hits an object with the enemy layer on.
                
                if(hitInfo.transform.gameObject.TryGetComponent(out EnemyMovement HitTarget)){
                    laserLine.SetPosition(1,hitInfo.point);
                    HitTarget.TakeDamage(Damage);
                }
                if(hitInfo.collider.gameObject.TryGetComponent(out TargetHealth hitTarget)){
                    laserLine.SetPosition(1,hitInfo.point);
                    hitTarget.TakeDamage(Damage);
                } 
            }

            //I used this to make it so in game3 a headshot is a 1 shot kill whereas it takes two shots to the body. 
            if(Physics.Raycast(gunshot, out RaycastHit hitInfo2, 100f, EnemyHeadLayer)){

                if(hitInfo2.transform.gameObject.TryGetComponent(out EnemyMovement HitTarget2)){
                    laserLine.SetPosition(1,hitInfo2.point);
                    HitTarget2.TakeDamage(HeadshotDamage);
                }
                
    
            }

            if(Physics.Raycast(gunshot, out RaycastHit hitInfo3, 100f, GroundLayer)){
                    laserLine.SetPosition(1,hitInfo3.point);

            }

            if(Physics.Raycast(gunshot, out RaycastHit hitInfo4, 100f, CrateLayer)){
                     if(hitInfo4.transform.gameObject.TryGetComponent(out CrateDestroy HitTarget4)){
                    laserLine.SetPosition(1,hitInfo4.point);
                    HitTarget4.DestroyCrate();
                }


            }


            StartCoroutine(shootLaser());

        }
        
    }
    

    IEnumerator shootLaser(){

        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false; 
    }
}
