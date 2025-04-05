using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject rocketLauncher;
    public GameObject quadLauncher;
    public GameObject grenadeLauncher;

    private bool[] unlocked = new bool[3];

    void Start()
    {
        unlocked[0] = true;
        // temp on true
        unlocked[1] = true;
        unlocked[2] = true;
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
        unlocked[index] = true;
    }
}
