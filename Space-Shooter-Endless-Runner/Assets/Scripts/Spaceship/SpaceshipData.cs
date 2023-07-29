using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipData : MonoBehaviour
{
    public int score;

    public static SpaceshipData instance;

    public int highScore;

    void Awake(){
        instance = this;
    }
    
    public int getScore(){
        return score;
    }

    public int getHighScore(){
        return highScore;
    }

}
