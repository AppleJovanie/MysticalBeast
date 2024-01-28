using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint1"))
        {
            // Save the checkpoint position and scene before destroying it
            SaveCheckpointData(collision.transform.position, SceneManager.GetActiveScene().name);

            // Destroy the checkpoint object
            Destroy(collision.gameObject);

            // Load the battle scene
            SceneManager.LoadScene("BattleScene");
            Debug.Log("You reached Checkpoint 1");
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
