using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AmmoManager : MonoBehaviour
{
    public static AmmoManager Instance;
    
    // Ammo settings for different levels
    [Header("Ammo Settings")]
    public int level2RocketLauncherAmmo = 10;
    public int level2QuadLauncherAmmo = 0;
    public int level2GrenadeLauncherAmmo = 0;
    
    // Current ammo counts
    private int rocketLauncherAmmo;
    private int quadLauncherAmmo;
    private int grenadeLauncherAmmo;
    
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
            rocketLauncherAmmo = level2RocketLauncherAmmo;
            quadLauncherAmmo = level2QuadLauncherAmmo;
            grenadeLauncherAmmo = level2GrenadeLauncherAmmo;
        }
        else
        {
            // Default to infinite ammo for other levels
            rocketLauncherAmmo = -1; // -1 means infinite
            quadLauncherAmmo = -1;
            grenadeLauncherAmmo = -1;
        }
        
        UpdateAmmoDisplay();
        FindAmmoText();
    }
    
    private void FindAmmoText()
    {
        if (ammoText == null)
        {
            ammoText = GameObject.FindGameObjectWithTag("AmmoText")?.GetComponent<TextMeshProUGUI>();
        }
        UpdateAmmoDisplay();
    }
    
    public void UpdateAmmoDisplay()
    {
        if (ammoText != null)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            
            if (currentScene == "Level2")
            {
                // Only show rocket launcher ammo for Level2
                ammoText.text = "Rockets: " + (rocketLauncherAmmo == -1 ? "∞" : rocketLauncherAmmo.ToString());
                ammoText.gameObject.SetActive(true);
            }
            else
            {
                // Hide ammo display for other levels
                ammoText.gameObject.SetActive(false);
            }
        }
    }
    
    public bool UseAmmo(int weaponType)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        // Only apply ammo limits in Level2
        if (currentScene != "Level2")
            return true;
            
        switch (weaponType)
        {
            case 0: // Rocket Launcher
                if (rocketLauncherAmmo > 0 || rocketLauncherAmmo == -1)
                {
                    if (rocketLauncherAmmo > 0) // Don't decrement if infinite (-1)
                        rocketLauncherAmmo--;
                    UpdateAmmoDisplay();
                    return true;
                }
                return false;
                
            case 1: // Quad Launcher
                if (quadLauncherAmmo > 0 || quadLauncherAmmo == -1)
                {
                    if (quadLauncherAmmo > 0)
                        quadLauncherAmmo--;
                    UpdateAmmoDisplay();
                    return true;
                }
                return false;
                
            case 2: // Grenade Launcher
                if (grenadeLauncherAmmo > 0 || grenadeLauncherAmmo == -1)
                {
                    if (grenadeLauncherAmmo > 0)
                        grenadeLauncherAmmo--;
                    UpdateAmmoDisplay();
                    return true;
                }
                return false;
                
            default:
                return true;
        }
    }
    
    public void ResetAmmo()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        if (currentScene == "Level2")
        {
            rocketLauncherAmmo = level2RocketLauncherAmmo;
            quadLauncherAmmo = level2QuadLauncherAmmo;
            grenadeLauncherAmmo = level2GrenadeLauncherAmmo;
            UpdateAmmoDisplay();
        }
    }
}