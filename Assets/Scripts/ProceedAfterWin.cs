using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceedAfterWin : MonoBehaviour
{
    //Map 1
    public void ProceedAfterHydrogen()
    {
        SceneManager.LoadScene(4);
    }
    public void ProceedAfterLithium()
    {
        SceneManager.LoadScene(6);
    }
    public void ProceedAfterSodium()
    {
        SceneManager.LoadScene(8);
    }
    public void ProceedAfterPotassium()
    {
        SceneManager.LoadScene(10);
    }

    public void ProceedAfterRubidium()
    {
        SceneManager.LoadScene(12);  // Proceed to the next map
    }


    // Map 2

    public void ProceedAfterTitanium()
    {
        SceneManager.LoadScene(14);  
    }
    public void ProceedAfterIron()
    {
        SceneManager.LoadScene(16);  
    }
    public void ProceedAfterCopper()
    {
        SceneManager.LoadScene(18);  
    }
    public void ProceedAfterSilver()
    {
        SceneManager.LoadScene(20);  
    }
    public void ProceedAfterGold()
    {
        SceneManager.LoadScene(22);  // Proceed to the next map
    }

    // Map 3

    public void ProceedAfterHelium()
    {
        SceneManager.LoadScene(24);
    }
    public void ProceedAfterNeon()
    {
        SceneManager.LoadScene(26);
    }
    public void ProceedAfterArgon()
    {
        SceneManager.LoadScene(28);
    }
    public void ProceedAfterKrypton()
    {
        SceneManager.LoadScene(30);
    }
    public void ProceedAfterXenon()
    {
        SceneManager.LoadScene(32); // DIRECT TO BOSS SCENE
    }
    public void DirectToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
