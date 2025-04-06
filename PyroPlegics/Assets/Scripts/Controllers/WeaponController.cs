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
        // Check GameObject references
        CheckWeaponReferences();
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
        // Check GameObject references again after scene load
        CheckWeaponReferences();
        UpdateWeaponAvailability();
        Debug.Log($"Scene loaded: {scene.name} - Weapons unlocked: [{unlocked[0]}, {unlocked[1]}, {unlocked[2]}]");
    }

    private void CheckWeaponReferences()
    {
        if (rocketLauncher == null)
            Debug.LogError("RocketLauncher reference is missing!");
        if (quadLauncher == null)
            Debug.LogError("QuadLauncher reference is missing!");
        if (grenadeLauncher == null)
            Debug.LogError("GrenadeLauncher reference is missing!");
    }

    private void UpdateWeaponAvailability()
    {
        // Get current scene name
        currentScene = SceneManager.GetActiveScene().name;
        Debug.Log($"Updating weapons for scene: {currentScene}");

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
        else if (currentScene == "Level4" || currentScene == "bossfight")
        {
            // All weapons
            unlocked[0] = true;
            unlocked[1] = true;
            unlocked[2] = true;
            Debug.Log("All weapons should be unlocked in bossfight!");
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
        // Debug weapon switching in bossfight scene
        if (currentScene == "bossfight" && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)))
        {
            Debug.Log($"Key pressed in bossfight - Weapons unlocked: [{unlocked[0]}, {unlocked[1]}, {unlocked[2]}]");
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) && unlocked[0])
        {
            Debug.Log("Switching to Rocket Launcher");
            SwitchWeapon(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) && unlocked[1])
        {
            Debug.Log("Switching to Quad Launcher");
            SwitchWeapon(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3) && unlocked[2])
        {
            Debug.Log("Switching to Grenade Launcher");
            SwitchWeapon(2);
        }
    }

    void SwitchWeapon(int weapon)
    {
        if (!unlocked[weapon])
        {
            Debug.Log($"Cannot switch to weapon {weapon} - it's not unlocked");
            return;
        }

        // Ensure references are valid before attempting to switch
        if ((weapon == 0 && rocketLauncher == null) ||
            (weapon == 1 && quadLauncher == null) ||
            (weapon == 2 && grenadeLauncher == null))
        {
            Debug.LogError($"Cannot switch to weapon {weapon} - reference is null");
            return;
        }

        // deactivate all weapons
        if (rocketLauncher != null) rocketLauncher.SetActive(false);
        if (quadLauncher != null) quadLauncher.SetActive(false);
        if (grenadeLauncher != null) grenadeLauncher.SetActive(false);

        // activate desired weapon
        if (weapon == 0 && rocketLauncher != null)
            rocketLauncher.SetActive(true);
        if (weapon == 1 && quadLauncher != null)
            quadLauncher.SetActive(true);
        if (weapon == 2 && grenadeLauncher != null)
            grenadeLauncher.SetActive(true);
            
        Debug.Log($"Weapon switched to {weapon}");
    }

    public void UnlockWeapon(int index)
    {
        if (index >= 0 && index < unlocked.Length)
            unlocked[index] = true;
    }
}