using UnityEngine;
using System.Collections.Generic;

public class DaggerInventory : MonoBehaviour
{
    [Header("Slots d'inventaire")]
    [SerializeField] private int maxDaggers = 4;
    [SerializeField] private KeyCode addDaggerKey = KeyCode.I;

    private List<Dagger> inventory = new List<Dagger>();
    private Dagger equippedDagger = null;

    private void Start()
    {
        inventory = new List<Dagger>(maxDaggers);
    }

    private void Update()
    {
        // Teste pour ajouter une dague (debug)
        if (Input.GetKeyDown(addDaggerKey))
        {
            Debug.Log($"Inventaire: {inventory.Count}/{maxDaggers} dagues");
        }
    }

    public bool AddDagger(Dagger dagger)
    {
        if (inventory.Count >= maxDaggers)
        {
            Debug.LogWarning("Inventaire plein ! Impossible d'ajouter une dague.");
            return false;
        }

        inventory.Add(dagger);
        dagger.Unequip();
        Debug.Log($"Dague '{dagger.DaggerName}' ajoutée à l'inventaire. ({inventory.Count}/{maxDaggers})");
        return true;
    }

    public bool RemoveDagger(Dagger dagger)
    {
        if (inventory.Contains(dagger))
        {
            inventory.Remove(dagger);
            if (equippedDagger == dagger)
            {
                equippedDagger = null;
            }
            Debug.Log($"Dague '{dagger.DaggerName}' retirée de l'inventaire.");
            return true;
        }
        return false;
    }

    public void EquipDagger(Dagger dagger)
    {
        if (!inventory.Contains(dagger))
        {
            Debug.LogWarning("Cette dague n'est pas dans l'inventaire!");
            return;
        }

        if (equippedDagger != null)
        {
            equippedDagger.Unequip();
        }

        equippedDagger = dagger;
        dagger.Equip();
        Debug.Log($"Dague '{dagger.DaggerName}' équipée !");
    }

    public void UnequipDagger()
    {
        if (equippedDagger != null)
        {
            equippedDagger.Unequip();
            equippedDagger = null;
            Debug.Log("Dague rangée.");
        }
    }

    public Dagger GetEquippedDagger() => equippedDagger;

    public List<Dagger> GetInventory() => inventory;

    public int GetInventoryCount() => inventory.Count;

    public int GetMaxSlots() => maxDaggers;
}
