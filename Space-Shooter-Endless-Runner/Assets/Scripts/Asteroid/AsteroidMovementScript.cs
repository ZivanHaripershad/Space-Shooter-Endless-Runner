using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovementScript : MonoBehaviour
{
    public float speed = 0.5f;
    public float deactiveTimer = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateGameObject", deactiveTimer);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        if(GameState.instance.getIsPlayerStillAlive()){
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp; 
        }
    }

    void DeactivateGameObject(){
        Destroy(gameObject);
    }
}
