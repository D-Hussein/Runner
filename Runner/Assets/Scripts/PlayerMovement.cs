using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource music;
    public AudioSource jump;
    public AudioSource fall;
    private float speed = 5.0f;
    private int lives = 0;
    public new Rigidbody rigidbody;
    //public Collider collider;

    private ScoreScript scoreScript;
    private int level;
    private bool grounded = true;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreScript = GetComponent<ScoreScript>();
      //  collider = GetComponent<Collider>();
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        level = scoreScript.getLevel();
        if(rigidbody.transform.position.y <= -0.6f){
            Death();
        }

        if(isDead){
            return;
        }

        float horizontal = 0.0f;
        float vertical = Time.deltaTime * speed;
        if(grounded){ 

            // Keyboard
            horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

            if(Input.GetButtonDown("Jump")){
               StartCoroutine(JumpUp());
            }

             // phone controls
            if(Input.GetMouseButtonDown(0)){

                if((Input.mousePosition.y > (Screen.height /2))){
                    StartCoroutine(JumpUp());
                } 
            }
            if(Input.GetMouseButton(0)){
                if(Input.mousePosition.x > Screen.width /2){
                    horizontal = Time.deltaTime * speed;
                }else{
                    horizontal = -Time.deltaTime * speed;
                }
            }

        }
        // Move character
        transform.Translate(horizontal,0,vertical);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Ground"){
            grounded = true;
        } 
        if(collision.gameObject.tag == "Obsticle"){
            Damage();
            if(lives<1){
                Death();
            }
        }
    }

    private IEnumerator JumpUp(){
        jump.Play();
        rigidbody.AddForce(new Vector3(0,4,0), ForceMode.Impulse);
        yield return null;
        grounded = false;
            
    }
    
    public void SpeedUp(float vlaue){
        speed += vlaue;
    }
    public float getSpeed(){
        return speed;
    }
    public int getLives(){
        return lives;
    }

    private void Death(){
        isDead = true;
        GetComponent<ScoreScript>().onDeath();
        fall.Play();
        music.Stop();
    }
    private void Damage(){
        lives--;
    }
    public bool getGrounded(){
        return grounded;
    }
}
