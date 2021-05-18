using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;

    private int currentLives;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();
        currentLives = playerMovement.getLives();
        animator.SetInteger("lives",currentLives);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed",playerMovement.getSpeed());
        
        // if(playerMovement.getSpeed()>5.0f){
        //     animator.SetBool("isRunning",true);
        // }
        if(playerMovement.getLives()<currentLives){
             animator.SetBool("hit",true);
            // animator.SetBool("hit",false);
            currentLives = playerMovement.getLives();
            animator.SetInteger("lives",currentLives);

        }

        if(playerMovement.getGrounded()){
            animator.SetBool("jump",false);
        }else{
            animator.SetBool("jump",true);
        }
        

        
    }
}
