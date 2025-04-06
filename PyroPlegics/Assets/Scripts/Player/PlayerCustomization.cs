using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    // Character parts to toggle visibility
    public GameObject hairOption; // Single hair GameObject
    public GameObject beardOption; // Single beard GameObject
    public GameObject moustacheOption; // Single moustache GameObject
    public GameObject shirtOption; // Single shirt GameObject
    public GameObject plateArmourOption; // Single plate armour GameObject

    // Renderers for color customization
    // IMPORTANT: Assign these in the Inspector with the appropriate SkinnedMeshRenderer components
    public Renderer bodyRenderer; // Assign the body mesh renderer here
    public Renderer underwearRenderer; // Assign underwear/pants mesh renderer here
    public Renderer hairRenderer; // Assign hair mesh renderer here

    private void Start()
    {
        
    }

    // Function to toggle hair
    public void ToggleHair()
    {
        ToggleOption(hairOption);
        // Update the manager with the new state
        if (CustomizationManager.Instance != null)
        {
            CustomizationManager.Instance.hairVisible = hairOption.activeSelf;
        }
    }

    // Function to toggle beard
    public void ToggleBeard()
    {
        ToggleOption(beardOption);
        if (CustomizationManager.Instance != null)
        {
            CustomizationManager.Instance.beardVisible = beardOption.activeSelf;
        }
    }

    // Function to toggle the MOUSTACHE
    public void ToggleMoustache()
    {
        ToggleOption(moustacheOption);
        if (CustomizationManager.Instance != null)
        {
            CustomizationManager.Instance.moustacheVisible = moustacheOption.activeSelf;
        }
    }

    // Function to toggle shirt
    public void ToggleShirt()
    {
        ToggleOption(shirtOption);
        if (CustomizationManager.Instance != null)
        {
            CustomizationManager.Instance.shirtVisible = shirtOption.activeSelf;
        }
    }

    // Function to toggle plate armour
    public void TogglePlateArmour()
    {
        ToggleOption(plateArmourOption);
        if (CustomizationManager.Instance != null)
        {
            CustomizationManager.Instance.plateArmorVisible = plateArmourOption.activeSelf;
        }
    }

    // Helper function to toggle a GameObject
    private void ToggleOption(GameObject option)
    {
        if (option != null)
        {
            option.SetActive(!option.activeSelf);
        }
    }

    // Methods to change colors
    public void ChangeBodyColor(Color newColor)
    {
        if (bodyRenderer != null)
        {
            bodyRenderer.material.color = newColor;
            if (CustomizationManager.Instance != null)
            {
                CustomizationManager.Instance.bodyColor = newColor;
            }
        }
    }

    public void ChangeUnderwearColor(Color newColor)
    {
        if (underwearRenderer != null)
        {
            underwearRenderer.material.color = newColor;
            if (CustomizationManager.Instance != null)
            {
                CustomizationManager.Instance.underwearColor = newColor;
            }
        }
    }

    public void ChangeHairColor(Color newColor)
    {
        if (hairRenderer != null)
        {
            hairRenderer.material.color = newColor;
            if (CustomizationManager.Instance != null)
            {
                CustomizationManager.Instance.hairColor = newColor;
            }
        }
    }
}