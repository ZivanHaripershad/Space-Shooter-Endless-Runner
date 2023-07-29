using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life1Update : MonoBehaviour
{
    public SpaceshipProperties spaceshipProperties;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spaceshipProperties.livesRemaining == 1){
            spriteRenderer.enabled = true;
        }
        else if(spaceshipProperties.livesRemaining == 0){
            spriteRenderer.enabled = false;
        }
    }
}
