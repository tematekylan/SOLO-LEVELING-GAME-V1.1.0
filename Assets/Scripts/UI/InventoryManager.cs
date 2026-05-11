using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventaire")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private KeyCode inventoryKey = KeyCode.Alpha3;
    [SerializeField] private bool startOpen = false;
    [SerializeField] private bool pauseWhenOpen = true;

    private bool inventoryOpen;

    private void Start()
    {
        if (inventoryPanel != null)
        {
            inventoryOpen = startOpen;
            inventoryPanel.SetActive(inventoryOpen);
            if (pauseWhenOpen && inventoryOpen)
            {
                Time.timeScale = 0f;
            }
        }
        else
        {
            Debug.LogWarning("InventoryManager: inventoryPanel n'est pas assigné.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            ToggleInventory();
        }

        if (inventoryOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInventory();
        }
    }

    public void ToggleInventory()
    {
        if (inventoryOpen)
        {
            CloseInventory();
        }
        else
        {
            OpenInventory();
        }
    }

    public void OpenInventory()
    {
        if (inventoryPanel == null) return;

        inventoryPanel.SetActive(true);
        inventoryOpen = true;

        if (pauseWhenOpen)
        {
            Time.timeScale = 0f;
        }
    }

    public void CloseInventory()
    {
        if (inventoryPanel == null) return;

        inventoryPanel.SetActive(false);
        inventoryOpen = false;

        if (pauseWhenOpen)
        {
            Time.timeScale = 1f;
        }
    }

    public bool IsInventoryOpen => inventoryOpen;
}
