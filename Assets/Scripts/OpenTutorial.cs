using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTutorial : MonoBehaviour
{
    public GameObject TutorialPanel;

    public void ShowTutorialPanel()
    {
        if (TutorialPanel != null)
        {
            bool isActive = TutorialPanel.activeSelf;
            TutorialPanel.SetActive(!isActive);
        }

    }

}
