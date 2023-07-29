using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDestroy : MonoBehaviour
{
    private Animator animator;

    public float destroyDelay = 0.5f;

    public SpaceshipProperties spaceshipProperties;

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
            explosionSoundEffect.Play();
            SpaceshipData.instance.score++;

            DestroyObjects(collision);
        }

        if (collision.gameObject.tag == "Spaceship")
        {
            hitSoundEffect.Play();

            if(animator.GetBool("isDestroyed") == false)
                spaceshipProperties.livesRemaining = spaceshipProperties.livesRemaining - 1;

            DestroyObjects(collision);
            
        }
    }

    void DestroyObjects(Collider2D collision){
        if (collision.gameObject.tag == "Bullet")
            Destroy(collision.gameObject);

        animator.SetBool("isDestroyed", true);

        Invoke("DestroyObject", destroyDelay);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
