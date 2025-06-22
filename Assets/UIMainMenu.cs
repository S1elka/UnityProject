using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIMainMenu : MonoBehaviour
{
    public string SceneName = "Scenes/SampleScene";
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame

    public TextMeshProUGUI gameOverText; // Поле для текста "Вы проиграли"
    public string gameOverMessage = "Вы проиграли!";

    public string gameWonMessage = "Вы прошли игру!! Поздравляю!";

    private static bool hasPlayerLost = false;
    private static bool hasPlayerWon = false;

    void Start()
    {
        if (hasPlayerLost && gameOverText != null)
        {
            gameOverText.text = gameOverMessage;
        }
        if (hasPlayerWon && gameOverText != null)
        {
            gameOverText.text = gameWonMessage;
        }
    }

    void Update()
    {

    }

    public void StartGame()
    {
        hasPlayerLost = false;
        hasPlayerWon = false;
        SceneManager.LoadScene(SceneName);
    }

    public static void SetGameOver()
    {
        hasPlayerLost = true;
    }

    public static void SetGameWon()
    {
        hasPlayerWon = true;
    }
}

