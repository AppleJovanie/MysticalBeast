using UnityEngine;
using UnityEngine.UI;

public class SwitchScript : MonoBehaviour
{
    public GameObject[] background;
    public Button previousButton;
    public Button nextButton; // Reference to the Next button

    private int index;

    private void Start()
    {
        index = 0;
        UpdateBackgroundVisibility();
        UpdateButtonInteractivity();
    }

    private void UpdateBackgroundVisibility()
    {
        for (int i = 0; i < background.Length; i++)
        {
            background[i].SetActive(i == index);
        }
    }

    private void UpdateButtonInteractivity()
    {
        if (previousButton != null)
        {
            previousButton.interactable = index > 0;
        }
        if (nextButton != null)
        {
            nextButton.interactable = index < background.Length - 1;
        }
    }

    public void Next()
    {
        index++;
        if (index >= background.Length)
        {
            index = background.Length - 1;
        }
        UpdateBackgroundVisibility();
        UpdateButtonInteractivity();
    }

    public void Previous()
    {
        index--;
        if (index < 0)
        {
            index = 0;
        }
        UpdateBackgroundVisibility();
        UpdateButtonInteractivity();
    }
}
