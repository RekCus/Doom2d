using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private Renderer rend;
    public PlayerMovement PM;

    [SerializeField]
    private Color colorToTurnTo = Color.white;
    [SerializeField]
    private Color colorToStart = Color.black;
    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<Renderer>();
        rend.material.color = colorToStart;
        //PM = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(PM.isSuitActive == true)
        {
            rend.material.color = colorToTurnTo;
            Debug.Log("YAAY");
        }
    }

}
