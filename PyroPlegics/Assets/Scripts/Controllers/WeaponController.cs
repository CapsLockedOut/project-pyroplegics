using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponController : MonoBehaviour
{
    public GameObject rocketLauncher;
    public GameObject quadLauncher;
    public GameObject grenadeLauncher;

    private bool[] unlocked = new bool[3];
    private string currentScene;

    void Start()
    {
        UpdateWeaponAvailability();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateWeaponAvailability();
    }

    private void UpdateWeaponAvailability()
    {
        // Get current scene name
        currentScene = SceneManager.GetActiveScene().name;

        // Reset all weapons to locked
        unlocked[0] = false;
        unlocked[1] = false;
        unlocked[2] = false;
        
        // Set weapon availability based on level
        if (currentScene == "Level1" || currentScene == "Level2")
        {
            // Only rocket launcher
            unlocked[0] = true;
        }
        else if (currentScene == "Level3")
        {
            // Rocket launcher and quad launcher
            unlocked[0] = true;
            unlocked[1] = true;
        }
        else if (currentScene == "Level4" || currentScene == "Level5")
        {
            // All weapons
            unlocked[0] = true;
            unlocked[1] = true;
            unlocked[2] = true;
        }
        else
        {
            // Default for any other scenes
            unlocked[0] = true;
        }
        
        // Switch to an available weapon
        for (int i = 0; i < unlocked.Length; i++)
        {
            if (unlocked[i])
            {
                SwitchWeapon(i);
                break;
            }
        }
    }

    // check for number key press
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && unlocked[0])
            SwitchWeapon(0);

        else if(Input.GetKeyDown(KeyCode.Alpha2) && unlocked[1])
            SwitchWeapon(1);

        else if(Input.GetKeyDown(KeyCode.Alpha3) && unlocked[2])
            SwitchWeapon(2);
    }

    void SwitchWeapon(int weapon)
    {
        if (!unlocked[weapon])
            return;

        // deactivate all weapons
        rocketLauncher.SetActive(false);
        quadLauncher.SetActive(false);
        grenadeLauncher.SetActive(false);

        // activate desired weapon
        if (weapon == 0)
            rocketLauncher.SetActive(true);
        if (weapon == 1)
            quadLauncher.SetActive(true);
        if (weapon == 2)
            grenadeLauncher.SetActive(true);
    }

    public void UnlockWeapon(int index)
    {
        if (index >= 0 && index < unlocked.Length)
            unlocked[index] = true;
    }
}