using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int lives = 3;
    public static bool playGame = true;
    public static bool Win = false;
    public static int numOfKills = 0;
 

    public Text livesText;
    public Text endScreen;
    public Text Restart;
    
    void Start()
    {
        livesText.text = "Lives:" + lives;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives:" + lives;
        if (lives == 0)
        {
            endScreen.text = "YOU LOSE!";
            Restart.text = "Press R to restart";
        }
        if (numOfKills >= 24)
        {
            endScreen.text = "YOU WIN!";
            Restart.text = "Press R to restart";
        }    
        
    }
}
