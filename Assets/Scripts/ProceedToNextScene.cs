using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProceedToNextScene : MonoBehaviour
{

    // After Defeating the Hydrogen it will proceed to another scene 
    public void ProceedAfterHydrogen() {

        SceneManager.LoadScene("MainScene2");
}
}
