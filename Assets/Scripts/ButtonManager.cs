using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ButtonManager : MonoBehaviour
{
    public List<RectTransform> snapPointAreas;
    public List<Image> imagePrefabs; // List of UI Image prefabs

    private List<Image> currentImages = new List<Image>();
    public GameObject attackBtn;
    public List<GameObject> CardElements = new List<GameObject>();

    void Start()
    {
        HideImages();
        HideAttackButton();
    }

    void Update()
    {
        // Check if both snap point areas are occupied, then show the attack button
        if (IsSnapPointAreaOccupied(0) && IsSnapPointAreaOccupied(1))
        {
            ShowAttackButton();
        }
        else
        {
            HideAttackButton();
        }
    }

    public void PressedButton1()
    {
        ShowNextImage(0);
    }

    public void PressedButton2()
    {
        ShowNextImage(1);
    }

    public void PressedButton3()
    {
        ShowNextImage(2);
    }

    //Elements buttons


    void ShowNextImage(int imageIndex)
    {
        // Iterate through snap point areas to find the first available one
        for (int i = 0; i < snapPointAreas.Count; i++)
        {
            // Check if the snap point area at this index is available and has the correct tag
            if (!IsSnapPointAreaOccupied(i) && (snapPointAreas[i].gameObject.CompareTag("SnapArea1") || snapPointAreas[i].gameObject.CompareTag("SnapArea2")))
            {
                // If the snap point area is not occupied and has the correct tag, instantiate and show the image
                Image imageInstance = Instantiate(imagePrefabs[imageIndex], snapPointAreas[i]);

                // Set the position of the image to match the snapPoint area
                imageInstance.GetComponent<RectTransform>().anchoredPosition = snapPointAreas[i].anchoredPosition;

                currentImages.Add(imageInstance); // Use the currentImages list to keep track of images
                return;
            }
        }

        // If all snap point areas are occupied or no suitable SnapArea found, do nothing or handle as needed
    }

    bool IsSnapPointAreaOccupied(int index)
    {
        // Check if the snap point area at this index is occupied
        return currentImages.Any(image => image != null && image.transform.parent == snapPointAreas[index]);
    }


    void ShowAttackButton()
    {    
        attackBtn.SetActive(true);
    }

    void HideAttackButton()
    {
        attackBtn.SetActive(false);
    }

    public void HideImages()
    {
        // Destroy the current images if they exist
        foreach (Image image in currentImages)
        {
            Destroy(image.gameObject);
        }
        currentImages.Clear();
    } 
}
