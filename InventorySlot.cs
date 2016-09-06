using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventorySlot : MonoBehaviour {

	//the location in the inventory grid x/y
	public int m_inventory_id;
	public GameObject manager;


	void Start()
	{
		updateSlot();
	}

	void OnEnable()
	{
		updateSlot();
	}

	//used for drag and drop functionality
	public int getSlotId()
	{
		return m_inventory_id;
	}

	public void updateSlot()
	{
		if (manager.GetComponent<InventoryManager>().getItemBySlotId (m_inventory_id) != null)
		{
			print ("found item");
			this.gameObject.GetComponent<Image>().sprite = manager.GetComponent<InventoryManager> ().getItemBySlotId (m_inventory_id).item.getSprite ();
		} 
		else
		{
			this.gameObject.GetComponent<Image>().sprite = null;
		}

	}

	public void equipItem()
	{

		manager.GetComponent<CharacterSheet>().equipItem(manager.GetComponent<InventoryManager>().getItemBySlotId(m_inventory_id).item);
	}
		
		
}
