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
        // Save current scene index
        PlayerPrefs.SetInt("SavedSceneIndex", SceneManager.GetActiveScene().buildIndex);

        // Save player position
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 playerPos = player.transform.position;
            PlayerPrefs.SetFloat("PlayerPosX", playerPos.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerPos.y);
            PlayerPrefs.SetFloat("PlayerPosZ", playerPos.z);
        }

        // Save PlayerPrefs
        PlayerPrefs.Save();

        Debug.Log("game saved");
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
