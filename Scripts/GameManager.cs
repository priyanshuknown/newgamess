using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Character player;
    public Character enemy;
    public Text messageText;
    public Button restartButton;

    private bool isGameOver = false;

    void Start()
    {
        messageText.text = "Fight!";
        restartButton.gameObject.SetActive(false);
        Invoke("HideMessage", 2f);
    }

    void Update()
    {
        if (isGameOver) return;

        if (player.currentHealth <= 0)
        {
            EndRound("You Lose!");
        }
        else if (enemy.currentHealth <= 0)
        {
            EndRound("You Win!");
        }
    }

    void EndRound(string message)
    {
        isGameOver = true;
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        // Disable character controllers
        player.enabled = false;
        enemy.enabled = false;
    }

    void HideMessage()
    {
        messageText.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
