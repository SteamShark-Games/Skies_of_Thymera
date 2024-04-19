using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNameKeeper : MonoBehaviour
{
    public static SceneNameKeeper Instance { get; private set; }
    string newSceneName; 
    string lastSceneName;

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            // If not, set the instance to this and mark it as persistent
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Start();
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Store the name of the current scene when this object is created
        lastSceneName = SceneManager.GetActiveScene().name;
    }

    public string GetLastSceneName()
    {
        return lastSceneName;
    }

    public void SetLastSceneName(string sceneName)
    {
        lastSceneName = sceneName;
    }
}

