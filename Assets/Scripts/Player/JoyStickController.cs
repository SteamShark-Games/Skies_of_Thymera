using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class ReselectLastSelectedOnInput : MonoBehaviour
{
    private InputSystemUIInputModule standaloneInputModule;
    private GameObject lastSelectedObject;
    public static ReselectLastSelectedOnInput instance;

    void Awake()
    {
        instance = this;
        standaloneInputModule = GetComponent<InputSystemUIInputModule>();
    }

    void Update()
    {
        CacheLastSelectedObject();
        if (EventSystemHasObjectSelected())
        {
            if (!EventSystem.current.currentSelectedGameObject.activeInHierarchy)
            {
                SelectNewButton();
            }
            return;
        }

        // If any axis/submit/cancel is pressed.
        if (standaloneInputModule.move.action.WasPressedThisFrame() ||
                standaloneInputModule.submit.action.WasPressedThisFrame() ||
                standaloneInputModule.cancel.action.WasPressedThisFrame())
        {
            // Reselect the cached 'lastSelectedObject'
            ReselectLastObject();
        }
    }

    // Called whenever a UI navigation/submit/cancel button is pressed.
    public static void ReselectLastObject()
    {
        // Do nothing if this is not active (maybe input objects were disabled)
        if (!instance.isActiveAndEnabled || !instance.gameObject.activeInHierarchy)
            return;

        // Otherwise we can proceed with setting the currently selected object to be 'lastSelectedObject'...

        // Current must be set to null first, otherwise it doesn't work properly because Unity UI is weird ¯\_(ツ)_/¯
        EventSystem.current.SetSelectedGameObject(null);

        // Set current to lastSelectedObject
        EventSystem.current.SetSelectedGameObject(instance.lastSelectedObject);
    }

    // Returns whether or not the EventSystem has anything selected
    static bool EventSystemHasObjectSelected()
    {
        return EventSystem.current.currentSelectedGameObject != null;
    }

    // Caches last selected object for later use
    void CacheLastSelectedObject()
    {
        // Don't cache if nothing is selected
        if (!EventSystemHasObjectSelected())
            return;
        lastSelectedObject = EventSystem.current.currentSelectedGameObject.gameObject;
    }

    // Selects a new button when the current button is not active
    void SelectNewButton()
    {
        // Find a new selectable button and set it as the selected object
        GameObject[] selectables = GameObject.FindGameObjectsWithTag("Selectable"); // Replace "Selectable" with the tag of your buttons
        foreach (GameObject selectable in selectables)
        {
            if (selectable.activeInHierarchy)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(selectable);
                lastSelectedObject = selectable;
                break;
            }
        }
    }
}
