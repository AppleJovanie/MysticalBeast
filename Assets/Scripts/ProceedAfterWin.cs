using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceedAfterWin : MonoBehaviour
{
    //Map 1
    public void ProceedAfterHydrogen()
    {
        SceneManager.LoadScene(3);
    }
    public void ProceedAfterLithium()
    {
        SceneManager.LoadScene(5);
    }
    public void ProceedAfterSodium()
    {
        SceneManager.LoadScene(7);
    }
    public void ProceedAfterPotassium()
    {
        SceneManager.LoadScene(9);
    }

    public void ProceedAfterRubidium()
    {
        SceneManager.LoadScene(11);  // Proceed to the next map
    }


    // Map 2

    public void ProceedAfterTitanium()
    {
        SceneManager.LoadScene(13);  
    }
    public void ProceedAfterIron()
    {
        SceneManager.LoadScene(15);  
    }
    public void ProceedAfterCopper()
    {
        SceneManager.LoadScene(17);  
    }
    public void ProceedAfterSilver()
    {
        SceneManager.LoadScene(19);  
    }
    public void ProceedAfterGold()
    {
        SceneManager.LoadScene(21);  // Proceed to the next map
    }

    // Map 3

    public void ProceedAfterHelium()
    {
        SceneManager.LoadScene(23);
    }
    public void ProceedAfterNeon()
    {
        SceneManager.LoadScene(25);
    }
    public void ProceedAfterArgon()
    {
        SceneManager.LoadScene(27);
    }
    public void ProceedAfterKrypton()
    {
        SceneManager.LoadScene(29);
    }
    public void ProceedAfterXenon()
    {
        SceneManager.LoadScene(31); // DIRECT TO CONTGRATS SCENE
    }
}
