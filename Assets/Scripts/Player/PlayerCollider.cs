using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public GameObject AlmanacPanel;
   

    public void ShowAlmanac()
    {
        if(AlmanacPanel != null)
        {
            bool isActive = AlmanacPanel.activeSelf;
            AlmanacPanel.SetActive(!isActive);
        }
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hydrogen"))
        {
            SceneManager.LoadScene(3);
        }
        if (collision.gameObject.CompareTag("LithiumEnemy"))
        {
            SceneManager.LoadScene(5);
           
        }
        if (collision.gameObject.CompareTag("SodiumEnemy"))
        {
            SceneManager.LoadScene(7);
         
        }
        if (collision.gameObject.CompareTag("PotassiumEnemy"))
        {
            SceneManager.LoadScene(9);
           
        }
        if (collision.gameObject.CompareTag("RubidiumEnemy"))
        {
            SceneManager.LoadScene(11);   
        }

        // Map 2

        if (collision.gameObject.CompareTag("TitaniumEnemy"))
        {
            SceneManager.LoadScene(13);
        }
        if (collision.gameObject.CompareTag("IronEnemy"))
        {
            SceneManager.LoadScene(15);
        }
        if (collision.gameObject.CompareTag("CopperEnemy"))
        {
            SceneManager.LoadScene(17);
        }
        if (collision.gameObject.CompareTag("SilverEnemy"))
        {
            SceneManager.LoadScene(19);
        }
        if (collision.gameObject.CompareTag("GoldEnemy"))
        {
            SceneManager.LoadScene(21);
        }

        // Map 3

        if (collision.gameObject.CompareTag("Helium"))
        {
            SceneManager.LoadScene(23);
        }
        if (collision.gameObject.CompareTag("NeonEnemy"))
        {
            SceneManager.LoadScene(25);
        }
        if (collision.gameObject.CompareTag("ArgonEnemy"))
        {
            SceneManager.LoadScene(27);
        }
        if (collision.gameObject.CompareTag("KryptonEnemy"))
        {
            SceneManager.LoadScene(29);
        }
        if (collision.gameObject.CompareTag("XenonEnemy"))
        {
            SceneManager.LoadScene(31);
        }

    }

    private void SaveCheckpointData(Vector3 checkpointPosition, string sceneName)
    {
        // Save the checkpoint position
        PlayerPrefs.SetFloat("CheckpointPosX", checkpointPosition.x);
        PlayerPrefs.SetFloat("CheckpointPosY", checkpointPosition.y);
        PlayerPrefs.SetFloat("CheckpointPosZ", checkpointPosition.z);

        // Save the current scene name
        PlayerPrefs.SetString("LastScene", sceneName);
        Debug.Log("Saved Checkpoint Data: " + checkpointPosition + " in Scene: " + sceneName);
    }

    public void LoadPlayerData()
    {
        // Check if the CheckPoint1 object has been destroyed
        GameObject checkpoint1 = GameObject.FindWithTag("CheckPoint1");
        if (checkpoint1 == null)
        {
            // Checkpoint1 has been destroyed, spawn at the last saved checkpoint position
            SpawnPlayerAtLastCheckpoint();
        }
        else
        {
            // Checkpoint1 is still present, spawn at its position
            player.transform.position = checkpoint1.transform.position;
        }

        Debug.Log("Loading Player Data...");

        // ... your existing code

        Debug.Log("Player Data Loaded.");
    }
    public void YouWonLvl1()
    {
        //Load the next Scenes
       // SceneManager.LoadScene();
   }

    private void SpawnPlayerAtLastCheckpoint()
    {
        // Load the last saved scene
        string lastScene = PlayerPrefs.GetString("LastScene", "MainScene");
        SceneManager.LoadScene(lastScene);

        // Load the last saved checkpoint position
        float checkpointPosX = PlayerPrefs.GetFloat("CheckpointPosX", 0f);
        float checkpointPosY = PlayerPrefs.GetFloat("CheckpointPosY", 0f);
        float checkpointPosZ = PlayerPrefs.GetFloat("CheckpointPosZ", 0f);

        // Set the player's position based on the loaded checkpoint data
        if (player != null)
        {
            player.transform.position = new Vector3(checkpointPosX, checkpointPosY, checkpointPosZ);
        }
    }
}
