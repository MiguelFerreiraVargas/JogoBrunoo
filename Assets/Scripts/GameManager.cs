using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int possessedCount = 0;
    private float timer = 15f;
    private bool gameStarted = false;
    private bool gameEnded = false;

    public TMP_Text timerText;
    public GameObject startText;
    public GameObject endPanel;
    public TMP_Text endText;
    public GameObject restartButton;

    void Awake()
    {
        instance = this;

        endPanel.SetActive(false);
        restartButton.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        if (gameStarted)
        {
            timer -= Time.deltaTime;
            timerText.text = "TEMPO: " + Mathf.Ceil(timer).ToString();

            if (timer <= 0)
            {
                EndGame(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                startText.SetActive(false);
                gameStarted = true;
            }
        }
    }

    public void AddPossession()
    {
        possessedCount++;

        if (possessedCount >= 3 && !gameEnded)
        {
            EndGame(true);
        }
    }

    void EndGame(bool venceu)
    {
        gameStarted = false;
        gameEnded = true;

        
        timerText.gameObject.SetActive(false);

        endPanel.SetActive(true);
        restartButton.SetActive(true);

        Time.timeScale = 0f;

        if (venceu)
        {
            endText.text = $"PARABENS, VOCÊ POSSUIU {possessedCount} PERSONAGENS E VENCEU!";
        }
        else
        {
            endText.text = $"TEMPO ESGOTADO! VOCÊ POSSUIU {possessedCount} PERSONAGENS.";
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
