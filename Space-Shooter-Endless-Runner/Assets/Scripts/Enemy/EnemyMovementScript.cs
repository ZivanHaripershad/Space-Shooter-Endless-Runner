using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactiveTimer = 5f;

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
