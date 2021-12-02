using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler levelHandlerInstance;
    private static string[] levels = new string[6] { "level_0", "level_1", "level_2", "level_3", "level_4", "level_5" };
    private string currentLevelString;
    // Start is called before the first frame update
    void Start()
    {
        //used to call functions in this from other scripts
        levelHandlerInstance = GetComponent<LevelHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        //Progresses to the next level when one is completed
        //Don't need a case for level_3 because that's the final level
        currentLevelString = SceneManager.GetActiveScene().name;
        switch(currentLevelString)
        {
            case "level_0":
                SceneManager.LoadScene("level_1");
                break;
            case "level_1":
                SceneManager.LoadScene("level_2");
                break;
            case "level_2":
                SceneManager.LoadScene("level_3");
                break;
        }
        
    }

    public void Gameover()
    {
        //Go back to level one when you gameover, or the tutorial level if you gameover while in the tutorial
        if(SceneManager.GetActiveScene().name == "level_0")
        {
            SceneManager.LoadScene("level_0");
        }
        else
        {
            SceneManager.LoadScene("level_1");
        }
    }

    public void StartGame()
    {
        //go to tutorial level when the play button is clicked on the main menu
        SceneManager.LoadScene("level_0");
    }


}
