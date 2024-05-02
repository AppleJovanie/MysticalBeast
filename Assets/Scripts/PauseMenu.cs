using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenuUI.activeSelf)
                Resume();
            else
                Pause();
        }
    }

    public void Save()
    {
        // Save the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedSceneIndex", currentSceneIndex);

        Debug.Log($"Game progress saved. Current scene index: {currentSceneIndex}");
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("SavedSceneIndex"))
        {
            // Load the saved scene
            int savedSceneIndex = PlayerPrefs.GetInt("SavedSceneIndex");
            SceneManager.LoadScene(savedSceneIndex);
        }
        else
        {
            Debug.Log("No saved data found.");
        }
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application quit");
    }
}
