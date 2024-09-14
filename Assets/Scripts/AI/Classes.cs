using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    private static System.Random rng = new System.Random();
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value; 
        }
    }
}

public static class Score
{
    private static int playerScore = 0;
    private static int enemyScore = 0;

    private static int bestScore = 0;

    public static void ScorePlayer(int amount)
    {
        playerScore += amount;
    }

    public static void ScoreEnemy(int amount)
    {
        enemyScore += amount;
    }

    public static int GetScorePlayer()
    {
        return playerScore;
    }

    public static int GetScoreEnemy()
    {
        return enemyScore;
    }

    public static void Reset()
    {
        playerScore = 0;
        enemyScore = 0;
    }

    public static void NewScore()
    {
        if(playerScore > bestScore)
        {
            bestScore = playerScore;
        }
    }

    public static int GetHighscore()
    {
        return bestScore;
    }
}

public static class Settings
{
    public static int time = 5;
    public static int size = 30;
}