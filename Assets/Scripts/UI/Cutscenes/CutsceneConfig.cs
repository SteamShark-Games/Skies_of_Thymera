using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using System;
using UnityEngine.SceneManagement;

public class CutsceneConfig : DialogueViewBase
{
    [SerializeField] RectTransform container;
    [SerializeField] TMPro.TextMeshProUGUI text;
    Action advanceHandler;

    float skipCutscene = 0;
    public string sceneName = "Level 1";
    List<GameObject> images = new List<GameObject>();

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
    }

    // Invokes player input to advance dialogue from cutscene
    public override void UserRequestedViewAdvancement()
    {
        if (container.gameObject.activeSelf)
        {
            advanceHandler?.Invoke();
        }
    }

    // Makes commands that can be called in a yarnspinner script to do functions as well as in this script
    // Used to edit and transition player to new scene either after it is skipped or finished
    [YarnCommand("FinishCutscene")]
    public void FinishCutscene()
    {
        Debug.Log("Switching to " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    // Sets all cutscene images and make them inactive until called in the yarnspinner script to be active
    [YarnCommand("ShowImage")]
    public void ShowImage(string filename)
    {
        foreach (var image in images)
        {
            image.SetActive(false);
        }

        var foundImage = images.Find(img => img.name == filename);
        if (foundImage != null)
        {
            foundImage.SetActive(true);
        }
        else
        {
            
        }
    }

    // Finds all images for cutscene and adds them to the list
    void Start()
    {
        foreach (Transform child in transform)
        {
            images.Add(child.gameObject);
        }
    }

    void Update()
    {
        // Allows keyboard/controller input to continue reading text
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetButtonDown("JoystickConfirm")))
        {
            UserRequestedViewAdvancement();
        }

        // Allows player to skip starting cutscene by pressing both methods of the pause button
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetButtonDown("JoystickPause")))
        {
            skipCutscene++;

            // Needs two inputs to skip cutscene, in place for extra confirmation or player error
            if (skipCutscene >= 2)
            {
                FinishCutscene();
            }
        }
    }
}
