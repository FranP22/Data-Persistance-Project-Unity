using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject timeObject;
    public GameObject sizeObject;
    public GameObject highscoreObject;

    private TextMeshProUGUI timeText;
    private TextMeshProUGUI sizeText;
    private TextMeshProUGUI highscoreText;
    public void StartGame()
    {
        try
        {
            string time = timeText.text;
            string size = sizeText.text;

            time = time.Substring(0, time.Length - 1);
            size = size.Substring(0, size.Length - 1);

            Debug.Log(time.Length);

            int timeNum = int.Parse(time);
            int sizeNum = int.Parse(size);

            Debug.Log(timeNum + " " + sizeNum);

            if(timeNum >= 5 && sizeNum >= 10 && sizeNum <=30)
            {
                Settings.time = timeNum;
                Settings.size = sizeNum;

                SceneManager.LoadScene(1);
                Score.Reset();
            }
            else
            {
                return;
            }
        }
        catch (Exception e) {
            Debug.Log(e);
            return;
        }
    }

    public void ExitGame()
    {
        Score.NewScore();
        SceneManager.LoadScene(0);
        Score.Reset();
    }

    private void Start()
    {
        try
        {
            timeText = timeObject.GetComponent<TextMeshProUGUI>();
            sizeText = sizeObject.GetComponent<TextMeshProUGUI>();
            highscoreText = highscoreObject.GetComponent<TextMeshProUGUI>();

            timeText.text = "5";
            sizeText.text = "20";

            highscoreText.text = "Highscore: " + Score.GetHighscore();
        }
        catch { }
    }

    private void Update()
    {
        /*if (highscoreText != null)
        {
            highscoreText.text = "Highscore: " + Score.GetHighscore();
        }*/
    }
}
