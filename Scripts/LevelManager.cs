/*Patrick Ruddy */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{




    public void LoadLevel(string name)
    {
        Debug.Log("Level Load Requested for " + name);
        SceneManager.LoadScene(name);
    } 

    public void Quit()
    {
        Debug.Log("Quit Button Pressed");
        Application.Quit();
    }


    /*Thanks to LoadNextLevel, this is irrelevant */
    public void LoadBetween(string level)
    {
       

        if (level == "Start")
        {
            SceneManager.LoadScene("Start");
        }
        else if (level == "Instructions")
        {
            SceneManager.LoadScene("Instructions");
        }
        else if (level == "Level_01")
        {
            SceneManager.LoadScene("Level_01");
        }
        else if (level == "Level_01B")
        {
            SceneManager.LoadScene("Level_01B");
        }
        else if (level == "Level_02")
        {
            SceneManager.LoadScene("Level_02");
        }
        else if (level == "Level_02B")
        {
            SceneManager.LoadScene("Level_02B");
        }
        else if (level == "Win")
        {
            SceneManager.LoadScene("Win");
        }
        
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

 /*   public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
            {
            LoadNextLevel();
        }
    }

    */

}
