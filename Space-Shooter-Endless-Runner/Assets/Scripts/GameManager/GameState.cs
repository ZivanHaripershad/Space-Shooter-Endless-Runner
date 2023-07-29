using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool isPlayerStillAlive;

    public static GameState instance;

    void Awake(){
        instance = this;
    }
    
    public bool getIsPlayerStillAlive(){
        return isPlayerStillAlive;
    }
}
