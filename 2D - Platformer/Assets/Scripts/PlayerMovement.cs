using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    private Renderer rend;

    public string levelToLoad;
    public int health = 100;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public bool isSuitActive;
    public bool pistolUnlocked;
    public bool shotgunUnlocked;

    public GameObject pistol, pistolEquip, enemy, player, eSpawn;
    public SceneTransition st;



    private void Start()
    {
        pistol.SetActive(true);
        pistolEquip.SetActive(false);
        enemy.SetActive(false);
        player.SetActive(true);
        eSpawn.SetActive(false);
        pistolUnlocked = false;
        health = 10;
        isSuitActive = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (health <= 0)
        {
            StartCoroutine(Death(1f));
        }

        // if(Input.GetKeyDown(Keycode.Q)){
        //  weaponArray++;
        //}
        //else if(Input.GetKeyDown(Keycode.E)){
        //  weaponArray--;
        //}


    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouch (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            health -= 10;
        }

        if (collision.gameObject.tag == "spikes")
        {
            health -= 100;
        }

        PickUp(collision);

        if (collision.gameObject.tag == "suit")
        {
            //code for suit
            Debug.Log("coll");
            eSpawn.SetActive(true);
            isSuitActive = true;
            health = 100;
            
        }

        if (collision.gameObject.tag == "door")
        {
            st.transitionEvn();
            
        }    


   }

    void PickUp(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("pistol"))
        {
            Debug.Log("pickup pistol");
            pistol.SetActive(false);
            pistolEquip.SetActive(true);
            enemy.SetActive(true);
            pistolUnlocked = true;
        }
        
    }

    IEnumerator Death(float time)
    {
        Debug.Log("hit");
        player.SetActive(false);
        yield return new WaitForSeconds(time);
        Debug.Log("Reset");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield break;
    }

    
}
