using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life3Update : MonoBehaviour
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
        if(spaceshipProperties.livesRemaining == 3){
            spriteRenderer.enabled = true;
        }
        else if(spaceshipProperties.livesRemaining == 2){
            spriteRenderer.enabled = false;
        }
    }
}
