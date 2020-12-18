using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes : MonoBehaviour
{
    public void selectscene()
    {
        switch (this.gameObject.name)
        {
            case "start":
                SceneManager.LoadScene ("Game");
                break;
            case "options":
                SceneManager.LoadScene ("Options");
                break;
            case "exit":
                Application.Quit();
                break;
            case "menu":
                SceneManager.LoadScene ("Mainmenu");
                break;
            case "playagain":
                SceneManager.LoadScene ("Game");
                break;
        }
    }
}
