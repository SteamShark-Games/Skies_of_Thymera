using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject LevelCompleteScene;
    public GameObject UI;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.enabled = false;
            LevelCompleteScene.SetActive(true);
            FadeOut();
        }
    }

    public void Start()
    {
        Time.timeScale = 1f;
    }

    private async void FadeOut()
    {
        await Task.Delay(2500);
        Time.timeScale = 0f;
        UI.SetActive(false);
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartButton()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentScene);
    }

    public void ContinueButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TestingGrounds");
    }
}
