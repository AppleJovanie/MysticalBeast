using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{
    public GameObject[] backgrounds;
    private int index;
    public Button nextButton;
    public Button previousButton;

    void Start()
    {
        index = 0;
        SetActiveBackground(index);
        UpdateNextButtonVisibility();
    }

    private void UpdateNextButtonVisibility()
    {
        // Hide the "Previous" button if we're at the first index
        if (index == 0)
        {
            previousButton.gameObject.SetActive(false);
        }
        else
        {
            previousButton.gameObject.SetActive(true);
        }
        // Hide the "Next" button if we're at the last background
        if (index >= backgrounds.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            nextButton.gameObject.SetActive(true);
        }
    }

    private void SetActiveBackground(int idx)
    {
        idx = Mathf.Clamp(idx, 0, backgrounds.Length - 1);
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(i == idx);
        }
    }

    public void Next()
    {
        index += 1;

        if (index >= backgrounds.Length)
        {
            LoadNextScene(); // Load the next scene
        }
        else
        {
            SetActiveBackground(index);
            UpdateNextButtonVisibility();
        }
    }

    public void Previous()
    {
        index -= 1;
        if (index < 0)
        {
            index = 0;
        }
        SetActiveBackground(index);
        UpdateNextButtonVisibility();
    }

    public void Skip()
    {
        LoadNextScene(); // Load the desired scene
    }

    private void LoadNextScene()
    {
        // Get the current scene and load the next scene based on the build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load.");
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
