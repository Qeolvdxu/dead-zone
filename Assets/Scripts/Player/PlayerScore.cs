using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore PScore;
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        PScore = GetComponent<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Other scripts can increase current score by the passed in amount
    public void IncreaseScore(int increaseAmount)
    {
        score += increaseAmount;
        HUD.playerHUD.UpdateScore(score);
    }

    //Other scripts can get current score
    public int GetScore()
    {
        return score;
    }

    //Other scripts can reset score to 0
    public void ResetScore()
    {
        score = 0;
    }

}
