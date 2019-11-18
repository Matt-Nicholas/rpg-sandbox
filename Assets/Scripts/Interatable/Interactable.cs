using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    private bool hasInteracted;

    public virtual void Interact()
    {
        Debug.Log("Interacting with Base Class: " + gameObject.name);

        hasInteracted = true;
        //TODO: If type of interactable is a wep. Consider adding option to press button that pops up a window to compare stats
    }

}
