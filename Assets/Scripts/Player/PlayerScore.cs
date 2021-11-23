using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore PScore;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        PScore = GetComponent<PlayerScore>();
        score = 0;
        print("Score is: " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void IncreaseScore(int increaseAmount)
    {
        score += increaseAmount;
        print("Score is: " + score);
    }

}
