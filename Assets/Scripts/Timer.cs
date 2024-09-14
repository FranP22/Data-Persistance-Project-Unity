using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI text;
    public GameObject overScreen;

    private bool gameOver = false;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        int time = Game.timeLeft;
        if (time < 0)
        {
            if (!gameOver)
            {
                gameOver = true;
                overScreen.SetActive(true);

                TextMeshProUGUI childText = overScreen.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
                if(Score.GetScorePlayer() > Score.GetScoreEnemy())
                {
                    //player won
                    childText.text = "Player Won";
                    childText.color = Color.blue;
                }else if(Score.GetScorePlayer() < Score.GetScoreEnemy())
                {
                    //enemy won
                    childText.text = "Enemy Won";
                    childText.color = Color.red;
                }
            }
            return;
        }

        int min = time / 60;
        int sec = time - min * 60;

        string minStr = min.ToString();
        string secStr = sec < 10 ? "0" + sec.ToString() : sec.ToString();
        text.text = minStr + ":" + secStr;
    }
}
