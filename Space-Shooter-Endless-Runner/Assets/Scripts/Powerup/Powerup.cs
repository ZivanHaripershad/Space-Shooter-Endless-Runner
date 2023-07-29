using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float speed = 0.8f;
    public float deactiveTimer = 20f;
    public SpaceshipProperties spaceshipProperties;

    [SerializeField]
    private AudioSource powerUpSoundEffect;

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
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spaceship" && gameObject.tag == "HealthPowerup")
        {
            powerUpSoundEffect.Play();

            if(spaceshipProperties.livesRemaining < 3){
                spaceshipProperties.livesRemaining ++;
            }

            DeactivateGameObject();  
        }

        if (collision.gameObject.tag == "Spaceship" && gameObject.tag == "2XPowerup")
        {
            powerUpSoundEffect.Play();

            SpaceshipData.instance.score = SpaceshipData.instance.score * 2;

            DeactivateGameObject();  
        }
    }

    void DeactivateGameObject(){
        Destroy(gameObject);
    }
}
