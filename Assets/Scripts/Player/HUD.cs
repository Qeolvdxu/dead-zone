using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [Header("Inspector - Set Values")]
    private TextMesh textScore, textLives;
    private Renderer gameoverText;
    public static HUD playerHUD;
    // Start is called before the first frame update
    void Start()
    {
        playerHUD = GetComponent<HUD>();
        textScore = this.transform.Find("ScoreText").GetComponent<TextMesh>();
        textLives = this.transform.Find("LivesText").GetComponent<TextMesh>();
        gameoverText = this.transform.Find("GameOverText").GetComponent<Renderer>();
        textLives.text = "Lives: " + PlayerLives.PLives.GetLives();
        UpdateScore(PlayerScore.PScore.GetScore());
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = MoveWithPlayerCamera.cameraInstance.GetCameraPosition();
    }

    public void UpdateScore(int newScore)
    {
        print("test");
        textScore.text = "Score: " + newScore;
    }

    public void RemoveLife()
    {
        PlayerLives.PLives.RemoveLife();
        textLives.text = "Lives: " + PlayerLives.PLives.GetLives();
        if(PlayerLives.PLives.GetLives() == 0)
        {
            Movement.player.EndGame();
        }
    }
    
    public void ShowGameover()
    {
        gameoverText.enabled = true;
    }
}
