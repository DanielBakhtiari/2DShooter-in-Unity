using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text t;
    public Text t1;
    // Start is called before the first frame update
    public static int score;
    private int high_score;
    void Start()
    {
        t.text = score.ToString();
        t1.text = "Score: " + score.ToString();
        score = 0;
        high_score = PlayerPrefs.GetInt("high_score", high_score);
    }


    // Update is called once per frame
    void Update()
    {
        t.text = "Score: " + score.ToString();
        t1.text = "High Score: " + high_score.ToString();
        if (score > high_score)
        {
            high_score = score;
            //Save high_score
            PlayerPrefs.SetInt ("high_score", high_score);
            PlayerPrefs.Save();
        }
    }
}
