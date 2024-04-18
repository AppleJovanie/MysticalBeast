using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        // Check if there's saved data for the game
        if (PlayerPrefs.HasKey("SavedSceneIndex"))
        {
            // Enable the Continue button
            continueButton.interactable = true;
        }
        else
        {
            // Disable the Continue button if there's no saved data
            continueButton.interactable = false;
        }
    }
    public Button continueButton;
    public void NewGame()
    {
        SceneManager.LoadScene(1); // Load the first game scene
    }

    public void ContinueGame()
    {
        // Check if there's saved data for the game
        if (PlayerPrefs.HasKey("SavedSceneIndex"))
        {
            // Load the game using the saved scene index
            int savedSceneIndex = PlayerPrefs.GetInt("SavedSceneIndex");
            SceneManager.LoadScene(savedSceneIndex);
        }
        else
        {
            // If there's no saved data, start a new game
            NewGame();
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
