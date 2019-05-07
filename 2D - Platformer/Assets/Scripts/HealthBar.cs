using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{


    public Slider healthBar;
    public PlayerMovement playerMovement;
    

    void Start()
    {
       // playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = playerMovement.health; 
    }
}
