using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int sceneToContinue;
    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        if (sceneToContinue != 0)
            SceneManager.LoadScene(sceneToContinue);
        else
            return;
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
