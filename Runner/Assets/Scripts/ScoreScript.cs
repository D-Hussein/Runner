using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public AudioSource levelUpSound;
    private float score = 0.0f;

    private int level = 1;
    private int lastLevel = 10;
    private int scoreToNextLevel = 10;
    public Text scoreText;
    public EndMenu endMenu;

    private bool isDead = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead){
            return;
        }
        if(score >= scoreToNextLevel){
            LevelUp();
            levelUpSound.Play();
        }

        score += Time.deltaTime *2;
        scoreText.text = ((int)level).ToString(); // Change to score
    }


    void LevelUp(){

        if(level == lastLevel){
            return;
        }

        scoreToNextLevel *= 2;
        level ++;
        GetComponent<PlayerMovement>().SpeedUp(2.0f);
    }

    public void onDeath(){
        isDead = true;
        if(PlayerPrefs.GetFloat("HighScore")< score){
            PlayerPrefs.SetFloat("HighScore",score);
        }
        
        endMenu.ToggleEndMenu(score); // Show the end menue and pass the end score
    }

    public int getLevel(){
        return level;
    }

}
