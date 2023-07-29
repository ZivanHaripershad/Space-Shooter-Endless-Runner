using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceshipMovement : MonoBehaviour
{
    public float speed = 5f;

    public float maxY = 3f;
    public float minY = -3f;

    [SerializeField]
    private GameObject leftBullet;

    [SerializeField]
    private GameObject rightBullet;

    [SerializeField]
    private Transform leftSpawnPoint;

    [SerializeField]
    private Transform rightSpawnPoint;
    

    private float shootTimer = 1f;
    private float currentShootTimer;
    private bool canShoot;

    public SpaceshipProperties spaceshipProperties;

    public GameObject endGamePanel;
    public Text gameOver;
    public Text scoreText;
    public Text restartGame;

    private bool isGameOver;

    [SerializeField]
    private AudioSource shootSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        currentShootTimer = shootTimer;
        spaceshipProperties.livesRemaining = 3;
        endGamePanel.SetActive(false);
        gameOver.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        restartGame.gameObject.SetActive(false);
        isGameOver = false;
        GameState.instance.isPlayerStillAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.instance.getIsPlayerStillAlive()){
            MovePlayer();
            Shoot();
            int score = SpaceshipData.instance.getScore();
            ScoreUi.instance.UpdateScore(score);
        }
        

        if(spaceshipProperties.livesRemaining == 0){
            GameState.instance.isPlayerStillAlive = false;
            isGameOver = true;
            EndGame();
        }
    }

    void MovePlayer(){
        if(Input.GetKey(KeyCode.W)){
            Vector3 temp = transform.position;
            temp.y += speed* Time.deltaTime;

            if(temp.y > maxY){
                temp.y = maxY;
            }

            transform.position = temp;
        }
        else if(Input.GetKey(KeyCode.S)){
            Vector3 temp = transform.position;
            temp.y -= speed* Time.deltaTime;

            if(temp.y < minY){
                temp.y = minY;
            }


            transform.position = temp;
        }
    }

    void Shoot(){
        shootTimer += Time.deltaTime;

        if(shootTimer > currentShootTimer){
            canShoot = true;
        }

        if(Input.GetKeyDown(KeyCode.Return) && canShoot){
            shootSoundEffect.Play();
            shootSoundEffect.Play();
            canShoot = false;
            shootTimer = 0f;

            Instantiate(leftBullet, leftSpawnPoint.position, Quaternion.identity);
            Instantiate(rightBullet, rightSpawnPoint.position, Quaternion.identity);
        }
    }

    public void EndGame(){
        if(SpaceshipData.instance.getScore() > SpaceshipData.instance.getHighScore()){
            scoreText.text = "NEW HIGH SCORE: " + SpaceshipData.instance.getScore().ToString();
            SpaceshipData.instance.highScore = SpaceshipData.instance.getScore();
        }
        else{
            scoreText.text = "SCORE: " + SpaceshipData.instance.getScore().ToString();
        }

        endGamePanel.SetActive(true);
        gameOver.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        restartGame.gameObject.SetActive(true);


        Invoke("Restart", 5f);

    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
