using UnityEngine;

public class Dagger : MonoBehaviour
{
    [Header("Stats de la dague")]
    [SerializeField] private string daggerName = "Dague";
    [SerializeField] private float baseDamage = 25f;
    [SerializeField] private float attackSpeed = 1.5f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private bool isPoisoned = false;
    [SerializeField] private float poisonDamagePerSecond = 0f;

    [Header("Couleur et style")]
    [SerializeField] private Color daggerColor = Color.white;
    [SerializeField] private Material daggerMaterial;

    private float lastAttackTime = 0f;
    private bool isEquipped = false;

    public string DaggerName => daggerName;
    public float BaseDamage => baseDamage;
    public float AttackSpeed => attackSpeed;
    public float AttackRange => attackRange;
    public bool IsPoisoned => isPoisoned;
    public float PoisonDamagePerSecond => poisonDamagePerSecond;
    public bool IsEquipped => isEquipped;

    private void Start()
    {
        if (daggerMaterial == null)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                daggerMaterial = renderer.material;
            }
        }
    }

    public void Equip()
    {
        isEquipped = true;
        if (daggerMaterial != null)
        {
            daggerMaterial.color = daggerColor;
        }
        gameObject.SetActive(true);
    }

    public void Unequip()
    {
        isEquipped = false;
        gameObject.SetActive(false);
    }

    public bool CanAttack()
    {
        return Time.time - lastAttackTime >= 1f / attackSpeed;
    }

    public void RecordAttack()
    {
        lastAttackTime = Time.time;
    }

    public float CalculateDamage()
    {
        float damage = baseDamage;
        if (isPoisoned)
        {
            damage *= 1.2f; // 20% bonus de dégâts si empoisonné
        }
        return damage;
    }
}
