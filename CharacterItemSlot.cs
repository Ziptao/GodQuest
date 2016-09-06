using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CharacterItemSlot : MonoBehaviour {
	
	private Item m_item;
	public GameObject inventory_manager;

	void Start()
	{
		m_item = new Item ();
	}


	public void setItem(Item item)
	{
		m_item = item;
	}

	public Item getItem()
	{
		return m_item;
	}

	//return the item to the inventory, only used for when gear becomes incompatible for use
	public bool unequipItem(Item item)
	{
		if (inventory_manager.GetComponent<InventoryManager> ().addItemToInventory (m_item, 1))
		{
			m_item = item;
			updateItemInfo();
			return true;
		} 
		else
		{
			return false;
		}
	}

	private void updateItemInfo()
	{

		this.gameObject.GetComponent<Image> ().sprite = m_item.getSprite();
	
	}

}
