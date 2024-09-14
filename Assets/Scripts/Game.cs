using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Spawn spawn;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject[] diamondPrefabs;
    public GameObject[] pickupPrefabs;

    public int time = 120;
    public static int timeLeft;

    void Start()
    {
        spawn.StartSpawn();

        Spawn.SpawnObject(playerPrefab, spawn.locations);
        Spawn.SpawnObject(enemyPrefab, spawn.locations);

        SpawnDiamonds(3);
        InvokeRepeating(nameof(SpawnDiamond),10,10);

        SpawnPickup();
        InvokeRepeating(nameof(SpawnPickup), 20, 20);

        time = Settings.time * 60;
        timeLeft = time;
        InvokeRepeating(nameof(TimeTick), 1, 1);
    }

    void Update()
    {
        
    }

    void TimeTick()
    {
        timeLeft--;
    }

    void SpawnDiamonds(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SpawnDiamond();
        }
    }

    void SpawnDiamond()
    {
        int diamond = SelectDiamond();
        if(diamond == -1)
        {
            return;
        }
        else
        {
            Spawn.SpawnObject(diamondPrefabs[diamond], spawn.locations);
        }
    }

    int SelectDiamond()
    {
        for (int i = diamondPrefabs.Length - 1; i >= 0; i--)
        {
            if (Random.Range(0, 1f) <= diamondPrefabs[i].GetComponent<Diamond>().chance)
            {
                return i;
            }
        }
        return -1;
    }

    void SpawnPickup()
    {
        Spawn.SpawnObject(pickupPrefabs[Random.Range(0,pickupPrefabs.Length)], spawn.locations);
    }
}
