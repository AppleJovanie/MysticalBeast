using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryForBoss : MonoBehaviour
{
    public GameObject[] backgrounds; // Changed to "backgrounds" for clarity
    private int index;
    public Button PrevButton;
    public Button nextButton; // Reference to the "Next" button

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        // Ensure the first background is active
        SetActiveBackground(index);

        // Update button visibility at the start
        UpdateButtonVisibility();
    }

    // Method to set the active background and deactivate others
    private void SetActiveBackground(int idx)
    {
        // Ensure the index is within bounds
        idx = Mathf.Clamp(idx, 0, backgrounds.Length - 1);
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(i == idx); // Activate only the selected background
        }
    }

    public void Next()
    {
        index += 1;

        if (index >= backgrounds.Length) // Check if index is out of bounds
        {
            // Load the next scene if index is out of bounds
            SceneManager.LoadScene(33);
        }
        else
        {
            SetActiveBackground(index); // Otherwise, update the background
        }

        // Update button visibility after changing index
        UpdateButtonVisibility();

        Debug.Log(index); // For debugging purposes
    }

    public void Previous()
    {
        index -= 1;
        if (index < 0)
        {
            index = 0; // Prevent going below zero
        }
        SetActiveBackground(index);

        // Update button visibility after changing index
        UpdateButtonVisibility();

        Debug.Log(index);
    }

    private void UpdateButtonVisibility()
    {
        // Hide the "Previous" button if we're at the first index
        PrevButton.gameObject.SetActive(index > 0);

       
    }

    public void Skip()
    {
        SceneManager.LoadScene(1); // Load the desired scene
    }
}
