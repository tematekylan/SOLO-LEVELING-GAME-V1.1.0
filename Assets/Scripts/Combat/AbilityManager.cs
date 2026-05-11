using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [Header("Abilities")]
    public TendrilsAbility tendrilsAbility;
    public BioBombAbility bioBombAbility;
    public AbsorptionAbility absorptionAbility;
    public SonarAbility sonarAbility;

    private void Start()
    {
        // Initialize abilities if not set
        if (tendrilsAbility == null)
            tendrilsAbility = GetComponent<TendrilsAbility>();
        if (bioBombAbility == null)
            bioBombAbility = GetComponent<BioBombAbility>();
        if (absorptionAbility == null)
            absorptionAbility = GetComponent<AbsorptionAbility>();
        if (sonarAbility == null)
            sonarAbility = GetComponent<SonarAbility>();
    }

    // Public methods to access abilities
    public void UseTendrils()
    {
        if (tendrilsAbility != null)
            tendrilsAbility.enabled = !tendrilsAbility.enabled;
    }

    public void UseBioBomb()
    {
        if (bioBombAbility != null)
            bioBombAbility.enabled = !bioBombAbility.enabled;
    }

    public void UseAbsorption()
    {
        if (absorptionAbility != null)
            absorptionAbility.enabled = !absorptionAbility.enabled;
    }

    public void UseSonar()
    {
        if (sonarAbility != null)
            sonarAbility.enabled = !sonarAbility.enabled;
    }
}