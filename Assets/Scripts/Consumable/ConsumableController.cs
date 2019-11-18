using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableController : MonoBehaviour {

    CharacterStats stats;

    private void Start()
    {
        stats = GetComponent<Player>().CharacterStats;
    }

    public void ConsumeItem(Item item)
    {
        GameObject itemToConsume = Instantiate(Resources.Load<GameObject>("Consumables/" + item.ObjectSlug));
        if(item.ItemModifier == true)
        {
            itemToConsume.GetComponent<IConsumable>().Consume(stats);
        }
        else
        {
            itemToConsume.GetComponent<IConsumable>().Consume();
        }

    }
}
