using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    public GameObject hairOption; // Single hair GameObject
    public GameObject beardOption; // Single beard GameObject
    public GameObject mustacheOption; // Single mustache GameObject
    public GameObject shirtOption; // Single shirt GameObject
    public GameObject plateArmourOption; // Single plate armour GameObject

    // Function to toggle hair
    public void ToggleHair()
    {
        ToggleOption(hairOption);
    }

    // Function to toggle beard
    public void ToggleBeard()
    {
        ToggleOption(beardOption);
    }

    // Function to toggle mustache
    public void ToggleMustache()
    {
        ToggleOption(mustacheOption);
    }

    // Function to toggle shirt
    public void ToggleShirt()
    {
        ToggleOption(shirtOption);
    }

    // Function to toggle plate armour
    public void TogglePlateArmour()
    {
        ToggleOption(plateArmourOption);
    }

    // Helper function to toggle a GameObject
    private void ToggleOption(GameObject option)
    {
        if (option != null)
        {
            option.SetActive(!option.activeSelf);
        }
    }
}