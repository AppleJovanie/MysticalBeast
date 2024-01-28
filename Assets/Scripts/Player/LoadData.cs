using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadData : MonoBehaviour
{
    public void LoadPlayerData()
    {
        // Load the last saved checkpoint position
        float checkpointPosX = PlayerPrefs.GetFloat("CheckpointPosX", 0f);
        float checkpointPosY = PlayerPrefs.GetFloat("CheckpointPosY", 0f);
        float checkpointPosZ = PlayerPrefs.GetFloat("CheckpointPosZ", 0f);

        // Set the player's position based on the loaded checkpoint data
        transform.position = new Vector3(checkpointPosX, checkpointPosY, checkpointPosZ);

        // Load the last saved scene
        string lastScene = PlayerPrefs.GetString("LastScene", "MainScene");
        SceneManager.LoadScene(lastScene);
    }
}
