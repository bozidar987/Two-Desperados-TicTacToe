using UnityEngine;

public class StatsPopup : MonoBehaviour
{
    Stats stats = new();
    [SerializeField] StatsManager statsManager;
    [SerializeField] TMPro.TextMeshProUGUI statsText;

    public void displayStats()
    {
        stats = statsManager.loadStats();
        statsText.text = $"Total Games Played: {stats.totalGamesPlayed}\n" +
                           $"Player 1 Wins: {stats.totalP1Wins}\n" +
                           $"Player 2 Wins: {stats.totalP2Wins}\n" +
                           $"Draws: {stats.totalDraws}\n" +
                           $"Average Playtime: {stats.averagePlaytime:F2}s";
    }
}
