using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizationManager : MonoBehaviour
{
    public static CustomizationManager Instance { get; private set; }
    
    // Visibility settings
    public bool hairVisible = true;
    public bool beardVisible = false;
    public bool moustacheVisible = false;
    public bool shirtVisible = true;
    public bool plateArmorVisible = false;
    
    // Color settings
    public Color bodyColor = Color.white;
    public Color underwearColor = Color.blue;
    public Color hairColor = Color.black;
    
    private void Awake()
    {
        // Singleton pattern to persist between scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Register to scene load event
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    // This will be called whenever a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the player in the new scene
        // Looking specifically for "Dante_Paraplegic Variant" prefab
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        
        if (playerObject != null)
        {
            PlayerCustomization playerCustom = playerObject.GetComponent<PlayerCustomization>();
            if (playerCustom != null)
            {
                ApplyToPlayer(playerCustom);
            }
            else
            {
                Debug.LogWarning("Player found but no PlayerCustomization component attached!");
            }
        }
        else
        {
            Debug.LogWarning("No player found in scene with tag 'Player'!");
        }
    }
    
    // Apply saved settings to a player customization component
    public void ApplyToPlayer(PlayerCustomization playerCustom)
    {
        // Set visibility
        if (playerCustom.hairOption) playerCustom.hairOption.SetActive(hairVisible);
        if (playerCustom.beardOption) playerCustom.beardOption.SetActive(beardVisible);
        if (playerCustom.moustacheOption) playerCustom.moustacheOption.SetActive(moustacheVisible);
        if (playerCustom.shirtOption) playerCustom.shirtOption.SetActive(shirtVisible);
        if (playerCustom.plateArmourOption) playerCustom.plateArmourOption.SetActive(plateArmorVisible);
        
        // Set colors
        if (playerCustom.bodyRenderer) playerCustom.bodyRenderer.material.color = bodyColor;
        if (playerCustom.underwearRenderer) playerCustom.underwearRenderer.material.color = underwearColor;
        if (playerCustom.hairRenderer) playerCustom.hairRenderer.material.color = hairColor;
    }
}