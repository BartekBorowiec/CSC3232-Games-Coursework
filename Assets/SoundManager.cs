using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip laserSound;
    static AudioSource AudioSrc; 

    // Start is called before the first frame update
    void Start()
    {
        laserSound = Resources.Load<AudioClip>("Laser_01");

        AudioSrc = GetComponent<AudioSource> (); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string sound){

        switch (sound){
        case "laser":
            AudioSrc.PlayOneShot (laserSound);
            break; 
        }
    }
}
