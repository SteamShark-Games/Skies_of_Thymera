using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject LevelCompleteScene;
    public GameObject UI;
    public GameObject Player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelCompleteScene.SetActive(true);
            StartCoroutine(Fade());
        }
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
        UI.SetActive(false);
        Player.SetActive(false);
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
        SceneManager.LoadScene("Level 2");
    }
}
