using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class Item
{
    public enum ItemTypes { Weapon, Consumable, Quest }

    public List<BaseStat> Stats { get; set; }
    public string ObjectSlug { get; set; }
    public string Description { get; set; }
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public ItemTypes ItemType { get; set; }
    public string ActionName { get; set; }
    public string ItemName { get; set; }
    public bool ItemModifier { get; set; }

    public Item(List<BaseStat> stats, string objectSlug)
    {
        Stats = stats;
        ObjectSlug = objectSlug;
    }

    [Newtonsoft.Json.JsonConstructor]
    public Item(List<BaseStat> stats, string objectSlug, string description, ItemTypes itemType, string actionName, string itemName, bool itemModifier)
    {
        Stats = stats;
        ObjectSlug = objectSlug;
        Description = description;
        ItemType = itemType;
        ActionName = actionName;
        ItemName = itemName;
        ItemModifier = itemModifier;
    }
}
