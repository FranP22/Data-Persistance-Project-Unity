using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class ScoreBar : MonoBehaviour
{
    private Slider slider;
    public bool player = true;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        int playerScore = Score.GetScorePlayer();
        int enemyScore = Score.GetScoreEnemy();
        int totalScore = playerScore + enemyScore;

        if(totalScore > 0)
        {
            if (player)
            {
                slider.value = (float)playerScore / totalScore;
            }
            else
            {
                slider.value = (float)enemyScore / totalScore;
            }
        }
        else
        {
            slider.value = 0;
        }
    }
}
