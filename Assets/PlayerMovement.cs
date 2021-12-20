using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject Player;

    [SerializeField]
    float walkSpeed = 2.5f;

    [SerializeField]
    float sprintSpeed = 5.0f;

    public CharacterController charController; 

    float speed = 2.5f; 

    [SerializeField]
    public float gravity = -25f;
    
    public float jumpHeight = 2f;
    
    Vector3 velocity; 

    public bool isGrounded;
    public bool checkGravity; 

    public float LastPositionY = 0f;
    public float FallDistance = 0f;

    private bool isSprinting; 

    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public int MaxHealth = 100; 
    public int CurrentHealth; 
    public HealthBar healthbar; 

    public bool checkTeleport = false; 
    public Teleport teleport; 

    private Animator anim;

    [SerializeField]
    private float WalkingStepSpeed = 0.5f;
    [SerializeField] 
    private float sprintStepMultiplier = 0.6f;
    [SerializeField]
    private AudioSource Audiosource;
    [SerializeField]
    private AudioClip[] clips;
    private float FootStepTimer = 0;
    private float StepSpeed; 

    private Vector3 lastPosition;
    private bool ismoving; 
    [SerializeField]
    private AudioClip[] LandClips; 

    

    public bool NotOnPlatform = true; 

    void Start()
    {
        //sets the players health to full
        charController = GetComponent<CharacterController>();
        CurrentHealth = MaxHealth;
        healthbar.HealthSet(MaxHealth);
        anim = gameObject.GetComponentInChildren<Animator>();

    }
    
   
    void Update()
    
    {   
        
        if(gravity == -25f){
            checkGravity = true; 
        }else{
            checkGravity = false; 
        }
        //checks whether the player is grounded to then know whether the player can jump or not. 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }


        //uses character controller to move left right or forward. 
        //In the camera script the body moves with the camera which means the player will move towards where the camera is facing. 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        charController.Move(move * speed * Time.deltaTime); 

        //applies force to the player to make it jump if it is grounded. 
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }
        
        //checks the distance the player has fallen 
        if(LastPositionY > Player.transform.position.y){
            FallDistance += LastPositionY - Player.transform.position.y;
        }
        LastPositionY = Player.transform.position.y;


        //fall damage to deal to the player if it has falled a distance greater than 5. 
        //there is also a gravity check so that there is no fall damage when the player is in low gravity. 
        if(FallDistance >= 5 && isGrounded && checkGravity && !checkTeleport){
            TakeDamage(5);
            
            AudioClip Landclip = GetRandomLandClip();
            Audiosource.PlayOneShot(Landclip);


            FallDistance = 0;
            LastPositionY = 0;

        }
        if(FallDistance <= 5 && isGrounded){
            FallDistance = 0;
            LastPositionY = 0;
            checkTeleport = false; 
        }

    
        
        velocity.y += gravity * Time.deltaTime;
        charController.Move(velocity* Time.deltaTime);

        //applies a speed increase when left shift is down for the player to sprint. 
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintSpeed; 
            isSprinting = true; 
        }
        isSprinting = false; 

        //if the shift key is up the player will be back to walking.
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {

            speed = walkSpeed; 
        }

        //applies the animation to the astronaut player model. 
         if (Input.GetKey ("w")) {
			anim.SetInteger ("AnimationPar", 1);
		}else {
			anim.SetInteger ("AnimationPar", 0);
		}

        //check to see if the player is moving or not. 
        if(lastPosition != gameObject.transform.position){
            ismoving = true; 
        }else{
            ismoving = false; 
        }
        lastPosition = gameObject.transform.position;

        //check to see if the player is sprinting or not. 
        if(isSprinting){
            StepSpeed = WalkingStepSpeed * sprintStepMultiplier;
        }else{
            StepSpeed = WalkingStepSpeed;
        }
        //does the checks to see if the footstep sound is needed. 
        if (isGrounded && ismoving && NotOnPlatform){
            FootStepSound();
        }
      
    }

    //timer to play the footstep sound. 
    private void FootStepSound(){
        
        FootStepTimer -=Time.deltaTime;

        if (FootStepTimer <= 0){
            AudioClip clip = GetRandomStepClip();
            Audiosource.PlayOneShot(clip);
            FootStepTimer = StepSpeed; 
        }
        
    }

    //picks a random clip from the array of clips for the footstep sound.
    private AudioClip GetRandomStepClip(){
        return clips[UnityEngine.Random.Range(0, clips.Length)]; 
    }    
    //picks a random clip from the array of clips for the player landing sound. 
    private AudioClip GetRandomLandClip(){
        return LandClips[UnityEngine.Random.Range(0, LandClips.Length)]; 
    }    

    private void OnControllerColliderHit(ControllerColliderHit hit){
        //if the player has collided with object with specific tags it will execute code after. 

        switch(hit.gameObject.tag){
            //changes the players gravity and jump force. 
            case "GravityPad":
                gravity = -11f;
                jumpHeight = 13f; 
                Destroy(GameObject.FindWithTag("GravityPad")); 
                break;
                //changes the players gravity and jump force back to normal. 
            case "NormalGravity":
                gravity = -15f;
                jumpHeight = 2f;
                break; 
        }
    }

    //function to be called whenever the player has taken damage. 
    public void TakeDamage(int damage){
        CurrentHealth -= damage;
        healthbar.HealthSet(CurrentHealth);
    }


    //a function to be called when the health is 0 and the player has died. 
    public void PlayerDeath(){
        gameObject.SetActive(false);
    }


    //function to change bool depending on whether the player is on the moving platform or not to not constantly make the footstep sound. 
    public void OnmovingPlatform(){

        if(NotOnPlatform == true){
            NotOnPlatform = false;
        }else if(NotOnPlatform == false){
            NotOnPlatform = true; 
        }
        Debug.Log(NotOnPlatform);
    }
}
