using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelAlmanac : MonoBehaviour
{
    public GameObject AlkaliMetals;
    public GameObject TransitionMetals;
    public GameObject Noblegas;

    public void ShowAlkaliMetals()
    {
        if (AlkaliMetals != null)
        {
            bool isActive = AlkaliMetals.activeSelf;
            AlkaliMetals.SetActive(!isActive);
        }
    }
    public void ShowTransitionMetals()
    {
        if (TransitionMetals != null)
        {
            bool isActive = TransitionMetals.activeSelf;
            TransitionMetals.SetActive(!isActive);
        }
    }
    public void ShowNobleGas()
    {
        if (Noblegas != null)
        {
            bool isActive = Noblegas.activeSelf;
            Noblegas.SetActive(!isActive);
        }
    }
}
