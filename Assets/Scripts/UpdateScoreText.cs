using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateScoreText : MonoBehaviour
{
    private TextMeshProUGUI text;
    public bool isPlayer = false;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        text.text = isPlayer ? Score.GetScorePlayer().ToString() : Score.GetScoreEnemy().ToString();
    }
}
