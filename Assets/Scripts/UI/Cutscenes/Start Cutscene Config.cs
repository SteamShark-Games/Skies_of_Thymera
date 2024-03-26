using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using System;
using UnityEngine.SceneManagement;

public class StartCutsceneConfig : DialogueViewBase
{
    [SerializeField] RectTransform container;
    [SerializeField] TMPro.TextMeshProUGUI text;
    Action advanceHandler;

    float skipCutscene = 0;


    // Active run line for dialogue and requests player input from controls to continue dialogue
    public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
    {
        container.gameObject.SetActive(true);
        text.text = dialogueLine.Text.Text;
        advanceHandler = requestInterrupt;
    }


    // Dismisses canvas once dialogue is exhausted + brings player to Level 1
    public override void DismissLine(Action onDismissalComplete)
    {
        container.gameObject.SetActive(false);
        onDismissalComplete();
        FinishCutscene();
    }


    // Invokes player input to advance dialogue from cutscene
    public override void UserRequestedViewAdvancement()
    {
        if(container.gameObject.activeSelf)
        {
            advanceHandler?.Invoke();
        }
    }

    // Once the cutscene is finished or skipped, brings player to Level 1
    public void FinishCutscene()
    {
        SceneManager.LoadScene("Level 1");
    }



    void Update()
    {
        // Allows keyboard/controller input to continue reading text
        if (Input.GetKey(KeyCode.Space) || (Input.GetButtonDown("JoystickConfirm")))
        {
            UserRequestedViewAdvancement();
        }

        // Allows player to skip starting curscene by pressing both methods of the pause button
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetButtonDown("JoystickPause")))
        {
            skipCutscene++;

            // Needs two inputs to skip cutscene, in place for extra confirmation or player error
            if (skipCutscene <= 2)
            {
                FinishCutscene();
            }
        }
    }
}
