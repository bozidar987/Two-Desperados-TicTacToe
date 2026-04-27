using UnityEngine;

 [System.Serializable]
 public class Stats
 {
     public int totalGamesPlayed = 0;
     public int totalP1Wins = 0;
     public int totalP2Wins = 0;
     public int totalDraws = 0;
     public float totalPlaytime = 0;
     public float averagePlaytime = 0;
        
 }
[CreateAssetMenu(fileName = "StatsManager", menuName = "Scriptable Objects/StatsManager")]

public class StatsManager : ScriptableObject
{

    Stats stats;
    private const string SaveKey = "TicTacToe_Stats";

    public void saveGameResult(int winner, float playtime)
    {
        stats = loadStats();
        stats.totalGamesPlayed++;
        stats.totalPlaytime += playtime;
        if(winner == 1)
        {
            stats.totalP1Wins++;
        }
        else if(winner == 2)
        {
            stats.totalP2Wins++;
        }
        else
        {
            stats.totalDraws++;
        }
        stats.averagePlaytime = stats.totalPlaytime / stats.totalGamesPlayed;

        string json = JsonUtility.ToJson(stats);
        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    public Stats loadStats()
    {
        if(PlayerPrefs.HasKey(SaveKey))
        {
            string json = PlayerPrefs.GetString(SaveKey);
            stats = JsonUtility.FromJson<Stats>(json);
        }
        else
        {
            stats = new Stats();
        }
        return stats;
    }
}
