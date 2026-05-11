using UnityEngine;

public class DaggerCombat : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] private DaggerInventory daggerInventory;
    [SerializeField] private Health playerHealth;

    [Header("Touches de contrôle")]
    [SerializeField] private KeyCode equipDagger1 = KeyCode.U;
    [SerializeField] private KeyCode equipDagger2 = KeyCode.O;
    [SerializeField] private KeyCode equipDagger3 = KeyCode.P;
    [SerializeField] private KeyCode equipDagger4 = KeyCode.L;
    [SerializeField] private KeyCode rangeDaggerKey = KeyCode.X;
    [SerializeField] private KeyCode attackKey = KeyCode.Mouse0;

    [Header("Combat")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float comboWindow = 1f;
    private float lastAttackTime = 0f;
    private int comboCount = 0;

    private void Start()
    {
        if (daggerInventory == null)
        {
            daggerInventory = GetComponent<DaggerInventory>();
        }

        if (playerHealth == null)
        {
            playerHealth = GetComponent<Health>();
        }
    }

    private void Update()
    {
        HandleEquipmentInput();
        HandleCombatInput();

        // Réinitialiser combo si trop de temps a passé
        if (Time.time - lastAttackTime > comboWindow)
        {
            comboCount = 0;
        }
    }

    private void HandleEquipmentInput()
    {
        // Équiper les dagues via les slots
        if (Input.GetKeyDown(equipDagger1))
        {
            EquipDaggerAtSlot(0);
        }
        if (Input.GetKeyDown(equipDagger2))
        {
            EquipDaggerAtSlot(1);
        }
        if (Input.GetKeyDown(equipDagger3))
        {
            EquipDaggerAtSlot(2);
        }
        if (Input.GetKeyDown(equipDagger4))
        {
            EquipDaggerAtSlot(3);
        }

        // Ranger la dague
        if (Input.GetKeyDown(rangeDaggerKey))
        {
            daggerInventory.UnequipDagger();
        }
    }

    private void HandleCombatInput()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            PerformAttack();
        }
    }

    private void EquipDaggerAtSlot(int slotIndex)
    {
        var inventory = daggerInventory.GetInventory();
        if (slotIndex < inventory.Count)
        {
            daggerInventory.EquipDagger(inventory[slotIndex]);
        }
        else
        {
            Debug.LogWarning($"Pas de dague au slot {slotIndex}");
        }
    }

    private void PerformAttack()
    {
        Dagger equippedDagger = daggerInventory.GetEquippedDagger();

        if (equippedDagger == null)
        {
            Debug.Log("Aucune dague équipée !");
            return;
        }

        if (!equippedDagger.CanAttack())
        {
            Debug.Log("Cooldown d'attaque en cours...");
            return;
        }

        float damages = equippedDagger.CalculateDamage();

        // Bonus de combo
        if (Time.time - lastAttackTime <= comboWindow)
        {
            comboCount++;
            damages *= (1f + (comboCount * 0.1f)); // 10% par coup de combo
            Debug.Log($"COMBO x{comboCount + 1} ! Dégâts: {damages:F1}");
        }
        else
        {
            comboCount = 0;
        }

        // Détecter les ennemis
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, equippedDagger.AttackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damages);
                Debug.Log($"{enemy.name} prend {damages:F1} dégâts !");

                // Appliquer le poison si la dague est empoisonnée
                if (equippedDagger.IsPoisoned)
                {
                    ApplyPoison(enemyHealth, equippedDagger.PoisonDamagePerSecond);
                }
            }
        }

        // Enregistrer l'attaque et afficher l'effet
        equippedDagger.RecordAttack();
        lastAttackTime = Time.time;

        // TODO: Ajouter animation et effets visuels
        Debug.Log($"Attaque avec {equippedDagger.DaggerName} ! Dégâts: {damages:F1}");
    }

    private void ApplyPoison(Health target, float poisonDPS)
    {
        // TODO: Implémenter un système de poison avec duration
        Debug.Log($"Poison appliqué ! {poisonDPS} dégâts/sec");
    }
}
