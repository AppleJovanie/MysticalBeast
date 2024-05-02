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
    public List<GameObject> CardsToHide = new List<GameObject>();


    void Start()
    {
       
        HideAttackButton();
        SetCardElementsInteractable(true);
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
   

    public void Hydrogen()
    {
        ShowNextImage(0);
    }

    public void Lithium()
    {
        ShowNextImage(1);
    }

    public void Sodium()
    {
        ShowNextImage(2);
    }
    public void Potassium()
    {
        ShowNextImage(3);
    }
    public void Rubidium()
    {
        ShowNextImage(4);
    }
    // Map 2
    
    public void Iron()
    {
        ShowNextImage(5);
    }
    public void Copper()
    {
        ShowNextImage(6);
    }
    public void Silver()
    {
        ShowNextImage(7);
    }
    public void Titanium()
    {
        ShowNextImage(8);
    }
    public void Gold()
    {
        ShowNextImage(9);
    }

    // Map3
    public void Xenon()
    {
        ShowNextImage(10);
    }
    public void Argon()
    {
        ShowNextImage(11);
    }
    public void Neon()
    {
        ShowNextImage(12);
    }
    public void Helium()
    {
        ShowNextImage(13);
    }
    public void Krypton()
    {
        ShowNextImage(14);
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
        SetCardElementsInteractable(false);
    }
    public void SetCardElementsInteractable(bool isInteractable)
    {
        foreach (var card in CardsToHide)
        {
            var button = card.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = isInteractable; // Set the interactability
            }

            var collider = card.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = isInteractable; // Enable/disable collider
            }
        }
    }

        void HideAttackButton()
    {
        attackBtn.SetActive(false);
    }

    public void HideAllCards()
    {
        foreach (GameObject card in CardElements)
        {
            card.SetActive(false);
        }
    }

    public void HideImages()
    {
        List<Image> imagesToClear = new List<Image>();

        // Iterate through the currentImages list to identify images in SnapArea1 or SnapArea2
        foreach (Image image in currentImages)
        {
            if (image != null)
            {
                if (image.transform.parent.gameObject.CompareTag("SnapArea1") ||
                    image.transform.parent.gameObject.CompareTag("SnapArea2"))
                {
                    imagesToClear.Add(image);
                }
            }
        }

        // Destroy the images that need to be cleared
        foreach (Image image in imagesToClear)
        {
            if (image != null)
            {
                Destroy(image.gameObject);
                currentImages.Remove(image);
            }
        }
       
    }

    public void ClearSnapAreas()
    {
        // Clear all children in SnapArea1 and SnapArea2
        foreach (var snapArea in snapPointAreas)
        {
            if (snapArea.gameObject.CompareTag("SnapArea1") ||
                snapArea.gameObject.CompareTag("SnapArea2"))
            {
                foreach (Transform child in snapArea)
                {
                    Destroy(child.gameObject);
                }
            }
        }

        // Update the `currentImages` list
        currentImages.RemoveAll(image => image != null 
                                        && (image.transform.parent.CompareTag("SnapArea1") 
                                        || image.transform.parent.CompareTag("SnapArea2")));

            SetCardElementsInteractable(true);
        
    }


 

}
