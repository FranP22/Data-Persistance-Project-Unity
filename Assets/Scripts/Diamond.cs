using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int value = 1;
    public float chance = 1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return;

        switch (other.gameObject.tag)
        {
            case "Player":
                Score.ScorePlayer(value);
                Destroy(gameObject);
                break;
            case "Enemy":
                Score.ScoreEnemy(value);
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
