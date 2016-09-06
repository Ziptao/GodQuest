using UnityEngine;
using System.Collections;

public class LootWindow : MonoBehaviour {

    public GameObject loot_inventory_object;
    

    public void ActivateWindow()
    {
        loot_inventory_object.SetActive(!loot_inventory_object.activeSelf);
    }    
}
