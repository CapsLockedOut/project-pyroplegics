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
            SwitchWeapon(rocketLauncher);

        else if(Input.GetKeyDown(KeyCode.Alpha2) && unlocked[1])
            SwitchWeapon(quadLauncher);

        else if(Input.GetKeyDown(KeyCode.Alpha3) && unlocked[2])
            SwitchWeapon(grenadeLauncher);
    }

    void SwitchWeapon(GameObject weapon)
    {
        // deactivate all weapons
        rocketLauncher.SetActive(false);
        quadLauncher.SetActive(false);
        grenadeLauncher.SetActive(false);

        // activate desired weapon
        weapon.SetActive(true);
    }

    public void UnlockWeapon(int index)
    {
        unlocked[index] = true;
    }
}
