using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager Instance;
    
    // Ammo settings for different levels
    [Header("Level 2 Ammo Settings")]
    public int rocketLauncherAmmo = 10;
    
    // Current ammo counts
    private int currentRocketAmmo;
    
    // UI Text to display ammo count
    [Header("UI References")]
    public TextMeshProUGUI ammoText;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
    
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Set ammo based on level
        if (scene.name == "Level2")
        {
            currentRocketAmmo = rocketLauncherAmmo;
        }
        else
        {
            // Infinite ammo for other levels
            currentRocketAmmo = -1; // -1 means infinite
        }
        
        // Find ammo text in new scene
        FindAmmoText();
        UpdateAmmoDisplay();
    }
    
    private void FindAmmoText()
    {
        if (ammoText == null)
        {
            // Try to find by tag
            GameObject textObj = GameObject.FindGameObjectWithTag("AmmoText");
            if (textObj != null)
            {
                ammoText = textObj.GetComponent<TextMeshProUGUI>();
            }
        }
    }
    
    public void UpdateAmmoDisplay()
    {
        if (ammoText != null)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            
            if (currentScene == "Level2")
            {
                // Display rocket launcher ammo for Level2
                ammoText.text = "Rockets: " + (currentRocketAmmo == -1 ? "∞" : currentRocketAmmo.ToString());
                ammoText.gameObject.SetActive(true);
            }
            else
            {
                // Hide ammo display for other levels
                ammoText.gameObject.SetActive(false);
            }
        }
    }
    
    public bool UseRocketAmmo()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        // Only apply ammo limits in Level2
        if (currentScene != "Level2")
            return true;
            
        if (currentRocketAmmo > 0 || currentRocketAmmo == -1)
        {
            if (currentRocketAmmo > 0) // Don't decrement if infinite (-1)
                currentRocketAmmo--;
            UpdateAmmoDisplay();
            return true;
        }
        return false;
    }
    
    public void ResetAmmo()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        if (currentScene == "Level2")
        {
            currentRocketAmmo = rocketLauncherAmmo;
            UpdateAmmoDisplay();
        }
    }
}