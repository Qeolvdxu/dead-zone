using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    private TextMesh textScore, textLives;
    public static HUD playerHUD;
    private int numLives;
    // Start is called before the first frame update
    void Start()
    {
        playerHUD = GetComponent<HUD>();
        textScore = this.transform.Find("ScoreText").GetComponent<TextMesh>();
        textLives = this.transform.Find("LivesText").GetComponent<TextMesh>();
        numLives = 3;
        textLives.text = "Lives: " + numLives;
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
        numLives--;
        textLives.text = "Lives: " + numLives;
        if(numLives == 0)
        {
            Movement.player.EndGame();
        }
    }
}
