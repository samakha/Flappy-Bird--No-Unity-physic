using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum GameplayState {  Intro , Playing , GameOver};
    public GameplayState state;

    public static GameManager Instance;
    public BirdController birdController;

    public GameObject scorePanel;
    public GameObject guideText; 
    private  int score;
    public TextMeshProUGUI  scoreText; 
    public TextMeshProUGUI  scoreOverPanelText; 
    public TextMeshProUGUI  highScoreText; 
    private static int hightScore; 
    private void Awake()
    {
        Instance = this; 
    }

    void Start()
    {
        scorePanel.SetActive(false);
        guideText.SetActive(true); 
        state = GameplayState.Intro;
        score = 0;
        birdController = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdController>();
        highScoreText.text = PlayerPrefs.GetInt("hightScore",0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        StartGame(); 
    }
    public void StartGame( ) 
    {
        if (state !=  GameplayState.Intro) //  display intro text
        {
            
        }
        if( Input.GetKeyDown(KeyCode.Space) && state!=GameplayState.GameOver) // starting play after press space button
        {
            state = GameplayState.Playing;
            guideText.SetActive(false); 
           //   birdController.isPlaying = true; 
        }
    }
    public void AddScore( ) // add score and check for high score
    {
        Debug.Log("score : " + score);
        score++;
        scoreText.text = score.ToString();
        scoreOverPanelText.text = score.ToString();

        if (score > PlayerPrefs.GetInt("hightScore",0))
        {
            PlayerPrefs.SetInt("hightScore", score);
            highScoreText.text = score.ToString(); 
        }
    }
  
    public void GameOver()
    {
        state = GameplayState.GameOver;
        // popup score panel
        scorePanel.SetActive(true); 

    }
    public void PlayAgain( )
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

}
