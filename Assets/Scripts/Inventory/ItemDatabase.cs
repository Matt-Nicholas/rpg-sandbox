using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : Singleton<ItemDatabase>
{
    List<Item> items { get; set; }

    private void Start()
    {
        BuildDatabase();
    }


    private void BuildDatabase()
    {
        items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
    }

    public Item GetItem(string itemSlug)
    {
        if (items == null) return null;

        foreach(Item item in items)
        {
            if(item.ObjectSlug == itemSlug)
                return item;
        }

        Debug.Log("Couln't find item: " + itemSlug);
        return null;
    }
}
