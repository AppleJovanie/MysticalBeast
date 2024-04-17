using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchForAlmanac : MonoBehaviour
{
    [Header("List Of Elements")]
    public GameObject[] AlkaliMetals;
    public GameObject[] TransitionMetals;
    public GameObject[] NobleGas;

    [Header("Alkali Buttons")]
    public Button previousAlkaliButton;
    public Button nextAlkaliButton;

    [Header("Transition Buttons")]
    public Button previousTransitionButton;
    public Button nextTransitionButton;

    [Header("NobleGas Buttons")]
    public Button previousNobleGasButton;
    public Button nextNobleGasButton;

    private int alkaliIndex;
    private int transitionIndex;
    private int nobleGasIndex;

    private void Start()
    {
        alkaliIndex = 0;
        transitionIndex = 0;
        nobleGasIndex = 0;
        UpdateBackgroundVisibility();
        UpdateButtonInteractivity();
    }

    private void UpdateBackgroundVisibility()
    {
        // Assuming you want to toggle visibility based on the index
        for (int i = 0; i < AlkaliMetals.Length; i++)
        {
            AlkaliMetals[i].SetActive(i == alkaliIndex);
        }
        for (int i = 0; i < TransitionMetals.Length; i++)
        {
            TransitionMetals[i].SetActive(i == transitionIndex);
        }
        for (int i = 0; i < NobleGas.Length; i++)
        {
            NobleGas[i].SetActive(i == nobleGasIndex);
        }
    }

    private void UpdateButtonInteractivity()
    {
        // Alkali Metals buttons
        if (previousAlkaliButton != null)
        {
            previousAlkaliButton.interactable = alkaliIndex > 0;
        }
        if (nextAlkaliButton != null)
        {
            nextAlkaliButton.interactable = alkaliIndex < AlkaliMetals.Length - 1;
        }

        // Transition Metals buttons
        if (previousTransitionButton != null)
        {
            previousTransitionButton.interactable = transitionIndex > 0;
        }
        if (nextTransitionButton != null)
        {
            nextTransitionButton.interactable = transitionIndex < TransitionMetals.Length - 1;
        }

        // Noble Gas buttons
        if (previousNobleGasButton != null)
        {
            previousNobleGasButton.interactable = nobleGasIndex > 0;
        }
        if (nextNobleGasButton != null)
        {
            nextNobleGasButton.interactable = nobleGasIndex < NobleGas.Length - 1;
        }
    }

    public void NextAlkali()
    {
        alkaliIndex++;
        if (alkaliIndex >= AlkaliMetals.Length)
        {
            alkaliIndex = AlkaliMetals.Length - 1;
        }
        UpdateBackgroundVisibility();
        UpdateButtonInteractivity();
    }

    public void PreviousAlkali()
    {
        alkaliIndex--;
        if (alkaliIndex < 0)
        {
            alkaliIndex = 0;
        }
        UpdateBackgroundVisibility();
        UpdateButtonInteractivity();
    }

    public void NextTransition()
    {
        transitionIndex++;
        if (transitionIndex >= TransitionMetals.Length)
        {
            transitionIndex = TransitionMetals.Length - 1;
        }
        UpdateBackgroundVisibility();
        UpdateButtonInteractivity();
    }

    public void PreviousTransition()
    {
        transitionIndex--;
        if (transitionIndex < 0)
        {
            transitionIndex = 0;
        }
        UpdateBackgroundVisibility();
        UpdateButtonInteractivity();
    }

    public void NextNobleGas()
    {
        nobleGasIndex++;
        if (nobleGasIndex >= NobleGas.Length)
        {
            nobleGasIndex = NobleGas.Length - 1;
        }
        UpdateBackgroundVisibility();
        UpdateButtonInteractivity();
    }

    public void PreviousNobleGas()
    {
        nobleGasIndex--;
        if (nobleGasIndex < 0)
        {
            nobleGasIndex = 0;
        }
        UpdateBackgroundVisibility();
        UpdateButtonInteractivity();
    }
}
