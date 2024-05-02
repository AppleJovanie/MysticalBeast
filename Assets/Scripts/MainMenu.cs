using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    private void Start()
    {
        // Check if there is a saved scene index in PlayerPrefs
        if (PlayerPrefs.HasKey("SavedSceneIndex"))
        {
            // Enable the continue button if there's saved data
            continueButton.interactable = true;
        }
        else
        {
            // Disable the continue button if there's no saved data
            continueButton.interactable = false;
        }
    }
  
    public void NewGame()
    {
        SceneManager.LoadScene(1); // Load the first game scene
    }

    public void ContinueGame()
    {
        if (PlayerPrefs.HasKey("SavedSceneIndex"))
        {
            int savedSceneIndex = PlayerPrefs.GetInt("SavedSceneIndex");
            SceneManager.LoadScene(savedSceneIndex);
        }
        else
        {
            Debug.Log("No saved data found. Starting a new game.");
            SceneManager.LoadScene(1); // Fallback to new game if no saved data
        }
    }

    public void OptionsMenu()
    {
        // Implement your options menu logic here
    }

    public void Quit()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
}
