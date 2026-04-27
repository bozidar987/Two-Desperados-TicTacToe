using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] Game game;

    [Header("Text objects")]
    [SerializeField] TMPro.TextMeshProUGUI timerText;
    [SerializeField] TMPro.TextMeshProUGUI p1TurnCounterText;
    [SerializeField] TMPro.TextMeshProUGUI p2TurnCounterText;
    [SerializeField] TMPro.TextMeshProUGUI turnIndicatorText;
    [SerializeField] TMPro.TextMeshProUGUI resultText;
    [SerializeField] TMPro.TextMeshProUGUI durationText;

    [Header("Other Objects")]
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject gameOverAnimation;
    [SerializeField] GameObject settingsButon;
    
    bool gameOver = false;
    
    private void Start()
    {
        updateHUD();
    }

    void Update()
    {
        if (!gameOver)
        {
            timerText.text = $"Timer: {game.getTimer():0.00}s";
        }
    }

    public void updateHUD()
    {
        gameOver = false;
        p1TurnCounterText.text = $"Player 1 Turns: {game.getP1TurnCount()}";
        p2TurnCounterText.text = $"Player 2 Turns: {game.getP2TurnCount()}";
        turnIndicatorText.text = $"Current Turn: Player {game.getCurrentPlayer()}";

        if (game.getCurrentPlayer() == 0)
        {
            endGame();
        }
    }

    void endGame() 
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        int winner = game.getWinner();
        if(winner == 0) 
        { 
            resultText.text = "It's a draw!";
        }
        else 
        {
            resultText.text = $"Player {winner} wins!";
            gameOverAnimation.SetActive(true);
        }
        durationText.text = $"Game Duration: {game.getTimer():0.00}s";

        timerText.text = "";
        p1TurnCounterText.text = "";
        p2TurnCounterText.text = "";
        turnIndicatorText.text = "";

        settingsButon.SetActive(false);
    }
}
