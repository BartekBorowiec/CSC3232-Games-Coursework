using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    //changes the slider value based on the players health. 
    public void HealthSet(int Health){
        slider.value = Health;
    }
}
