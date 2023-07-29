using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUi : MonoBehaviour
{

    public static ScoreUi instance;

    public Text scoreText;

    void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text= "Score: 0";
    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
