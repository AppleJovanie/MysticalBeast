using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject ShowAlmanac;

    public void OpenPanel()
    {
        if (ShowAlmanac != null)
        {
            bool isActive = ShowAlmanac.activeSelf;
            ShowAlmanac.SetActive(!isActive); 
        }

    }
}
