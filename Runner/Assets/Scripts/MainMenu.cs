using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Text highScoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        highScoreTxt.text = "High Score : "+ (int)PlayerPrefs.GetFloat("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
