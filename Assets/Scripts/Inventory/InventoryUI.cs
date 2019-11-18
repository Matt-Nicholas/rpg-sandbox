using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public RectTransform inventoryPanel;
    public RectTransform scrollViewContainer;
    InventoryUIItem itemContainer { get; set; }
    bool menuIsActive { get; set; }
    Item currentSelectedItem { get; set; }
    PlayerController pc;
    void Start ()
    {
        itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        inventoryPanel.gameObject.SetActive(false);
        pc = GetComponent<PlayerController>();
	}

    private void Update()
    { 
        // Add event that will alert that the inventory button has been pressed by a specific controller id
        if(pc != null && InputManager.SelectButtonDown(pc.ControllerID))
        {
            menuIsActive = !menuIsActive;
            inventoryPanel.gameObject.SetActive(menuIsActive);
        }
    }

    public void ItemAdded(Item item)
    {
        InventoryUIItem emptyItem = Instantiate(itemContainer);
        emptyItem.SetItem(item);
        emptyItem.transform.SetParent(scrollViewContainer);
    }
}
