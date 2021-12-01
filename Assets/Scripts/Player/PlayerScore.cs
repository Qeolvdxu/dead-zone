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
        print("Score is: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void IncreaseScore(int increaseAmount)
    {
        score += increaseAmount;
        HUD.playerHUD.UpdateScore(score);
        print("Score is: " + score);
    }


    public int GetScore()
    {
        return score;
    }

}
