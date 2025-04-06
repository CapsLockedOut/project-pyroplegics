using UnityEngine;
using UnityEngine.UI;

public class CustomizationUI : MonoBehaviour
{
    // Reference to the player in the customization scene
    public PlayerCustomization playerCustom;
    
    // Toggle UI elements - assign these in the Inspector
    public Toggle hairToggle;
    public Toggle beardToggle;
    public Toggle moustacheToggle;
    public Toggle shirtToggle;
    public Toggle plateArmorToggle;
    
    // Color selection UI - could be buttons or sliders
    [Header("Body Color Selection")]
    public Button[] bodyColorButtons;
    
    [Header("Underwear Color Selection")]
    public Button[] underwearColorButtons;
    
    [Header("Hair Color Selection")]
    public Button[] hairColorButtons;
    
    public Color[] colorPresets;
    
    private void Start()
    {
        // Find the player if not assigned
        if (playerCustom == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerCustom = player.GetComponent<PlayerCustomization>();
            }
        }
        
        // Initialize UI elements
        InitializeUI();
        
        // Set up UI event handlers
        SetupUIEventHandlers();
    }
    
    private void InitializeUI()
    {
        if (playerCustom != null)
        {
            // Set toggle states based on current visibility
            if (hairToggle != null && playerCustom.hairOption != null)
                hairToggle.isOn = playerCustom.hairOption.activeSelf;
            
            if (beardToggle != null && playerCustom.beardOption != null)
                beardToggle.isOn = playerCustom.beardOption.activeSelf;
            
            if (moustacheToggle != null && playerCustom.moustacheOption != null)
                moustacheToggle.isOn = playerCustom.moustacheOption.activeSelf;
            
            if (shirtToggle != null && playerCustom.shirtOption != null)
                shirtToggle.isOn = playerCustom.shirtOption.activeSelf;
            
            if (plateArmorToggle != null && playerCustom.plateArmourOption != null)
                plateArmorToggle.isOn = playerCustom.plateArmourOption.activeSelf;
        }
        
        // Set up color button appearances
        for (int i = 0; i < bodyColorButtons.Length && i < colorPresets.Length; i++)
        {
            if (bodyColorButtons[i] != null)
            {
                Image buttonImage = bodyColorButtons[i].GetComponent<Image>();
                if (buttonImage != null)
                {
                    buttonImage.color = colorPresets[i];
                }
            }
        }
        

        for (int i = 0; i < underwearColorButtons.Length && i < colorPresets.Length; i++)
        {
            if (underwearColorButtons[i] != null)
            {
                Image buttonImage = underwearColorButtons[i].GetComponent<Image>();
                if (buttonImage != null)
                {
                    buttonImage.color = colorPresets[i];
                }
            }
        }

        for (int i = 0; i < hairColorButtons.Length && i < colorPresets.Length; i++)
        {
            if (hairColorButtons[i] != null)
            {
                Image buttonImage = hairColorButtons[i].GetComponent<Image>();
                if (buttonImage != null)
                {
                    buttonImage.color = colorPresets[i];
                }
            }
        }
    }
    
    private void SetupUIEventHandlers()
    {
        // Set up toggle event handlers
        if (hairToggle != null){
            hairToggle.onValueChanged.AddListener(isOn => {
                if (playerCustom != null && playerCustom.hairOption != null)
                    playerCustom.hairOption.SetActive(isOn);
                if (CustomizationManager.Instance != null)
                    CustomizationManager.Instance.hairVisible = isOn;
            });
        }
        if (shirtToggle != null)
            shirtToggle.onValueChanged.AddListener(isOn => {
                if (playerCustom != null && playerCustom.shirtOption != null)
                    playerCustom.shirtOption.SetActive(isOn);
                if (CustomizationManager.Instance != null)
                    CustomizationManager.Instance.shirtVisible = isOn;
            });
        if (plateArmorToggle != null)
            plateArmorToggle.onValueChanged.AddListener(isOn => {
                if (playerCustom != null && playerCustom.plateArmourOption != null)
                    playerCustom.plateArmourOption.SetActive(isOn);
                if (CustomizationManager.Instance != null)
                    CustomizationManager.Instance.plateArmorVisible = isOn;
            });
        if (moustacheToggle != null) 
            moustacheToggle.onValueChanged.AddListener(isOn => {
                if (playerCustom != null && playerCustom.moustacheOption != null)
                    playerCustom.moustacheOption.SetActive(isOn);
                if (CustomizationManager.Instance != null)
                    CustomizationManager.Instance.moustacheVisible = isOn;
            });
        
        // Similar for other toggles...
        if (beardToggle != null)
            beardToggle.onValueChanged.AddListener(isOn => {
                if (playerCustom != null && playerCustom.beardOption != null)
                    playerCustom.beardOption.SetActive(isOn);
                if (CustomizationManager.Instance != null)
                    CustomizationManager.Instance.beardVisible = isOn;
            });
        

        
        
        // Set up color button click handlers
        for (int i = 0; i < bodyColorButtons.Length && i < colorPresets.Length; i++)
        {
            int index = i; // Needed for closure
            if (bodyColorButtons[i] != null)
            {
                bodyColorButtons[i].onClick.AddListener(() => {
                    if (playerCustom != null)
                        playerCustom.ChangeBodyColor(colorPresets[index]);
                });
            }
        }
        
        // Similar for underwear and hair color buttons
        // Similar code for underwearColorButtons and hairColorButtons...
        for (int i = 0; i < underwearColorButtons.Length && i < colorPresets.Length; i++)
        {
            int index = i; // Needed for closure
            if (underwearColorButtons[i] != null)
            {
                underwearColorButtons[i].onClick.AddListener(() => {
                    if (playerCustom != null)
                        playerCustom.ChangeUnderwearColor(colorPresets[index]);
                });
            }
        }

        for (int i = 0; i < hairColorButtons.Length && i < colorPresets.Length; i++)
        {
            int index = i; // Needed for closure
            if (hairColorButtons[i] != null)
            {
                hairColorButtons[i].onClick.AddListener(() => {
                    if (playerCustom != null)
                        playerCustom.hairRenderer.material.color = Color.blue;
                        //playerCustom.ChangeHairColor(colorPresets[index]);
                });
            }
        }


    }
}