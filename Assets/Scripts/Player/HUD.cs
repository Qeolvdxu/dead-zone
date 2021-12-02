using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    private TextMesh textScore, textLives, textWinScore;
    private Renderer gameoverText, winText, winScore;
    public static HUD playerHUD;
    //private static int score = 0;
    //private static int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        //used to access functions in this script from other scripts
        playerHUD = GetComponent<HUD>();
        //Used to modify text in the script
        textScore = this.transform.Find("ScoreText").GetComponent<TextMesh>();
        textLives = this.transform.Find("LivesText").GetComponent<TextMesh>();
        textWinScore = this.transform.Find("WinScore").GetComponent<TextMesh>();

        //used to show and hide parts of the hud
        gameoverText = this.transform.Find("GameOverText").GetComponent<Renderer>();
        winText = this.transform.Find("WinText").GetComponent<Renderer>();
        winScore = this.transform.Find("WinScore").GetComponent<Renderer>();

        //Initialize lives and score
        textLives.text = "Lives: " + 3;
        UpdateScore(PlayerScore.PScore.GetScore());
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = MoveWithPlayerCamera.cameraInstance.GetCameraPosition();
    }

    //allows other scripts to update player score
    public void UpdateScore(int newScore)
    {
        textScore.text = "Score: " + newScore;
    }

    //allows other scripts to remove player lives
    public void RemoveLife()
    {
        PlayerLives.PLives.RemoveLife();
        textLives.text = "Lives: " + PlayerLives.PLives.GetLives();
        if(PlayerLives.PLives.GetLives() == 0)
        {
            Movement.player.EndGame();
        }
    }
    
    //allows other scripts to trigger showing the gameover screen
    public void ShowGameover()
    {
        gameoverText.enabled = true;
    }

    //allows other scripts to trigger showing the win screen
    public void ShowWin()
    {
        textWinScore.text = "Final Score: " + PlayerScore.PScore.GetScore();
        winText.enabled = true;
        winScore.enabled = true;
    }
}
