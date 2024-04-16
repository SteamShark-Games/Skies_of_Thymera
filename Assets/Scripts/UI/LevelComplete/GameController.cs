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
    bool levelCompletion = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelComplete();
        }
    }

    public void LevelComplete()
    {
        Player.GetComponent<Player>().enabled = false;
        LevelCompleteScene.SetActive(true);
        levelCompletion = true;
        StartCoroutine(Fade());
    }

    void Update()
    {
       if (levelCompletion == true && Input.GetButtonDown("JoystickCancel"))
        {
            MenuButton();
        }

       if (levelCompletion == true && Input.GetButtonDown("JoystickRanged"))
        {
            RestartButton();
        }

       if (levelCompletion == true && Input.GetButtonDown("JoystickConfirm"))
        {
            ContinueButton();
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
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentScene + 1);
    }
}
