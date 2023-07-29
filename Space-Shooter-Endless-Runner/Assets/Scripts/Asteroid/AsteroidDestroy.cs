using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroy : MonoBehaviour
{
    private Animator animator;

    public float destroyDelay = 0.5f;

    public float lives = 3;

    public float decreaseAmount = 0.25f;

    public SpaceshipProperties spaceshipProperties;

    [SerializeField]
    private GameObject healthPowerup;

    [SerializeField]
    private Transform healthPowerupSpawnPoint;

    [SerializeField]
    private GameObject twoXMultiplierPowerup;

    [SerializeField]
    private Transform twoXMultiplierPowerupSpawnPoint;

    [SerializeField]
    private AudioSource explosionSoundEffect;

    [SerializeField]
    private AudioSource hitSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            --lives;

            DecreaseScale();

            if(lives == 0){
                explosionSoundEffect.Play();

                //destroy the bullet
                if (collision.gameObject.tag == "Bullet")
                    Destroy(collision.gameObject);

                animator.SetBool("isDestroyed", true);

                Invoke("DestroyObject", destroyDelay);

                int randomNum = GetRandomNumber();

                if(randomNum == 3){
                    Instantiate(healthPowerup, healthPowerupSpawnPoint.position, Quaternion.identity);
                }
                else{
                    Instantiate(twoXMultiplierPowerup, twoXMultiplierPowerupSpawnPoint.position, Quaternion.identity);
                }

                
            }
            
        }

        if (collision.gameObject.tag == "Spaceship")
        {
            hitSoundEffect.Play();

            if(animator.GetBool("isDestroyed") == false)
                spaceshipProperties.livesRemaining = spaceshipProperties.livesRemaining - 1;

            animator.SetBool("isDestroyed", true);

            Invoke("DestroyObject", destroyDelay);
            
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    void DecreaseScale(){
        Vector3 currentScale = transform.localScale;
        Vector3 newScale = new Vector3(currentScale.x - decreaseAmount, currentScale.y - decreaseAmount, currentScale.z);

        transform.localScale = newScale;
    }

    int GetRandomNumber()
    {
        int randomNumber = Random.Range(1, 6);
        return randomNumber;
    }
}
