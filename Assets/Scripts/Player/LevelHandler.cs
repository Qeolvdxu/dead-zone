using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler levelHandlerInstance;
    private static string[] levels = new string[6] { "level_0", "level_1", "level_2", "level_3", "level_4", "level_5" };
    private static int currentLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelHandlerInstance = GetComponent<LevelHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene(levels[currentLevel]);
        
    }

    public void Gameover()
    {
        currentLevel = 1;
        SceneManager.LoadScene(levels[currentLevel]);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levels[0]);
    }


}
