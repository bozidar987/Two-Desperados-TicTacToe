using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Game : MonoBehaviour
{
    enum GameState
    {
        Draw,
        Player1,
        Player2,
        GameOver
    }
    class Cell
    {
        public int value = 0;
        public Button button = null;
        public Image mark = null;
    }

    [Header("Managers")]
    [SerializeField] ThemeManager themeManager;
    [SerializeField] StatsManager statsManager;
    [SerializeField] SoundManager soundManager;

    GameState currentState;
    GameState startingPlayer;
    GameState winner;

    float timer;
    int player1TurnCount = 0;
    int player2TurnCount = 0;

    List<Cell> cells = new List<Cell>();
    List<List<int>> winConditions = new List<List<int>>();

    void Awake()
    {
        timer = 0f;
        winConditions.Add(new List<int> { 0, 1, 2 });
        winConditions.Add(new List<int> { 3, 4, 5 });
        winConditions.Add(new List<int> { 6, 7, 8 });
        winConditions.Add(new List<int> { 0, 3, 6 });
        winConditions.Add(new List<int> { 1, 4, 7 });
        winConditions.Add(new List<int> { 2, 5, 8 });
        winConditions.Add(new List<int> { 0, 4, 8 });
        winConditions.Add(new List<int> { 2, 4, 6 }); 

        System.Random rand = new System.Random();
        startingPlayer = (rand.Next(0, 2) == 0) ? GameState.Player1 : GameState.Player2;
        currentState = startingPlayer;

        for (int i = 0; i < transform.childCount; i++) 
        {
            Cell cell = new Cell();
            cell.value = 0;
            cell.mark = transform.GetChild(i).GetChild(0).GetComponent<Image>();
            cell.button = transform.GetChild(i).GetComponent<Button>();
            cells.Add(cell);
        }
    }

    private void Update()
    {
        if(currentState != GameState.GameOver)
        {
            timer += Time.deltaTime;
        }
    }

    public void playTurn(int cellIndex) 
    {
        if(currentState == GameState.Draw||currentState == GameState.GameOver) 
        {
            return;
        }
        if(cells[cellIndex].value != 0) 
        {
            return;
        }

        int playerValue = 0;
        if (currentState == GameState.Player1)
        {
            playerValue = 1;
            player1TurnCount++;
        }
        else if (currentState == GameState.Player2)
        {
            playerValue = 2;
            player2TurnCount++;
        }
        cells[cellIndex].value = playerValue;
        cells[cellIndex].mark.sprite = themeManager.setMark(playerValue);

        if (!endCheck(cellIndex, playerValue))
        {
            if (currentState == GameState.Player1)
            {
                currentState = GameState.Player2;
            }
            else
            {
                currentState = GameState.Player1;
            }
        }
    }

    bool endCheck(int cellIndex, int cellValue) 
    {
        for(int i = 0; i < winConditions.Count; i++)
        {
            if(winConditions[i].Contains(cellIndex))
            {
                if(cells[winConditions[i][0]].value == cellValue && cells[winConditions[i][1]].value == cellValue && cells[winConditions[i][2]].value == cellValue)
                {
                    winner = currentState;
                    endGame();
                    return true;
                }
            }
        }
        if(player1TurnCount + player2TurnCount == cells.Count) 
        {
            winner = GameState.Draw;
            endGame();
            return true;
        }
        return false;
    }

    void endGame() 
    {
        currentState = GameState.GameOver;
        soundManager.playEndGameSfx();
        for (int i = 0; i < cells.Count; i++)
        {
            cells[i].button.interactable = false;
        }
    }
    public void resetGame() 
    {
        timer = 0f;
        player1TurnCount = 0;
        player2TurnCount = 0;
        if (startingPlayer == GameState.Player1)
        {
            currentState = GameState.Player2;
            startingPlayer = GameState.Player2;
        }
        else
        {
            currentState = GameState.Player1;
            startingPlayer = GameState.Player1;
        }
        for(int i = 0; i < cells.Count; i++)
        {
            cells[i].value = 0;
            cells[i].mark.sprite = null;
            cells[i].mark.gameObject.SetActive(false);
            cells[i].button.interactable = true;
        }
    }

    public float getTimer() 
    {
        return timer;
    }

    public int getP1TurnCount() 
    {
        return player1TurnCount;
    }

    public int getP2TurnCount() 
    {
        return player2TurnCount;
    }

    public int getCurrentPlayer() 
    {
        if (currentState == GameState.Player1)
        {
            return 1;
        }
        else if (currentState == GameState.Player2)
        {
            return 2;
        }
        return 0;
    }

    public int getWinner() 
    {
        if (winner == GameState.Player1)
        {
            return 1;
        }
        else if (winner == GameState.Player2)
        {
            return 2;
        }
        return 0;
    }

    public void saveStats() 
    {
        statsManager.saveGameResult(getWinner(),timer);
    }
}
