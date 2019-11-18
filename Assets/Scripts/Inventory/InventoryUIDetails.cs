using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUIDetails : MonoBehaviour {
    Item _item;
    Button _selectedItemButton, _itemInteractButton;
    Text _itemNameText, _itemDescriptionText, _itemInteractButtonText;
    Text _statText;

    private void Start()
    {
        _itemNameText = transform.Find("Item_Name").GetComponent<Text>();
        _itemDescriptionText = transform.Find("Description").GetComponent<Text>();
        _itemInteractButton = transform.Find("Item_Interact_Button").GetComponent<Button>();
        _itemInteractButtonText = _itemInteractButton.transform.Find("Text").GetComponent<Text>();
        _statText = transform.Find("Stat_List").Find("Text").GetComponent<Text>();
        //TODO: make this a toggle that animates and plays a sound or something cool
        gameObject.SetActive(false);
    }

    public void SetItem(Item item, Button selectedButton)
    {
        gameObject.SetActive(true);
        _statText.text = "";
        if(item.Stats != null)
        {
            foreach(BaseStat stat in item.Stats)
            {
                _statText.text += stat.StatName + ": " + stat.BaseValue + Environment.NewLine; 
            }
        }
        _itemInteractButton.onClick.RemoveAllListeners();
        _item = item;
        _selectedItemButton = selectedButton;
        _itemNameText.text = item.ItemName;
        _itemDescriptionText.text = item.Description;
        _itemInteractButtonText.text = item.ActionName;
        _itemInteractButton.onClick.AddListener(OnItemInteract);
    }

    public void OnItemInteract()
    {
        if(_item.ItemType == Item.ItemTypes.Consumable)
        {
            InventoryController.Instance.ConsumeItem(_item);
            Destroy(_selectedItemButton.gameObject);
        }
        else if(_item.ItemType == Item.ItemTypes.Weapon)
        {
            InventoryController.Instance.EquipItem(_item);
            Destroy(_selectedItemButton.gameObject);
        }
        _item = null;
        gameObject.SetActive(false);
    }
}
