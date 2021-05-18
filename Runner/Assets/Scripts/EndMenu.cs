using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public Text scoreText;
    public Image backgroundImg;
    private bool isShowne = false;
    private float transition = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);    // hide the end menu
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShowne){
            return;
        }
        transition += Time.deltaTime/3;
        backgroundImg.color = Color.Lerp(new Color(0,0,0,0),Color.grey,transition);
    }

    public void ToggleEndMenu(float score){
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShowne = true;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart Scene
    }

    public void ToMainMenu(){
        SceneManager.LoadScene("MenuScene");
    }
}
