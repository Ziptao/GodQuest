using UnityEngine;
using System.Collections.Generic;

public class InventoryItem
{

	public InventoryItem(Item i, int c)
	{
		item = i;
		count = c;
	}
	//item held in this slot
	public Item item;
	//number of the item held
	public int count;
}
	
public class InventoryManager : MonoBehaviour {

	public const int MAX_SLOTS = 35;
	public GameObject inventory_object;


	//HANDLE THE PLAYER INVENTORY BASED ON SLOT ID AND ITEM HELD
	public List<InventoryItem> inventory_item_list = new List<InventoryItem>();

	void Start()
	{
		
		for (int i = 0; i < MAX_SLOTS; ++i)
		{
			Item item_slot = new Item();
			InventoryItem item = new InventoryItem(item_slot, -1);
			if (i == 5)
			{
				item.item.setName ("test");
				item.item.m_icon_sprite = Resources.Load<Sprite>("Sprites/Brazier");
				item.item.setItemEquipType (EquippableClass_e.CHEST);
				item.count = 1;
			}

			inventory_item_list.Add (item);
		}

	}

	void Update()
	{
		//if I is pressed disable//enable inventory
		if (Input.GetKeyDown(KeyCode.I))
		{
			inventory_object.SetActive(!inventory_object.activeSelf);
		}
	}
		
	//return the specific item located at the inventory slot selected at the UI
	public InventoryItem getItemBySlotId(int id)
	{
		if (inventory_item_list.Count > id)
		{
			return inventory_item_list [id];
		}
		else
		{
			return null;
		}
	}

	//remove item from the inventory
	public void removeItem(int location_id)
	{
		inventory_item_list[location_id].item = null;
	}

	public bool addItemToInventory(Item item, int count)
	{
		bool item_added = false;

		if (item != null)
		{
			InventoryItem inv_item = new InventoryItem (item, count);

			//check if item is stackable
			if (inv_item.item.isStackable())
			{
				//check if we already have this item in inventory
				int location = hasItemByName(inv_item.item.getItemName(), 1);
				if (location != -1)
				{
					print ("already have item, increment count");
					//add number item amount to inventory
					inventory_item_list[location].count += count;
					item_added = true;
				}
			}
			//get the first empty slot and assign this item to it
			else
			{
				print ("adding item!");
				//if there is an empty slot, assign the item to it
				int slot = findFirstEmptySlot();

				if (slot != -1)
				{
					inventory_item_list [slot] = inv_item;
					item_added = true;
				}
				else
				{
					print ("no empty slots available");
				}

			}
		}


		return item_added;
	}

	private int findFirstEmptySlot()
	{
		int slot = -1;

		for (int i = 0; i < MAX_SLOTS; ++i)
		{
			print ("checking for empty slot");
			if (inventory_item_list [i].count == -1)
			{
				slot = i;
				break;
			}
		}

		return slot;
	}
		
	public void swapInventorySlots(int slot1, int slot2)
	{
		if (slot1 != -1 && slot2 != -1)
		{
			InventoryItem temp;
			temp = inventory_item_list[slot1];
			inventory_item_list[slot1] = inventory_item_list[slot2];
			inventory_item_list[slot2] = temp;
		}
	}


	//determine if the player has the item and the amount requested, getting back a -1 means we don't
	public int hasItemByName(string name, int count)
	{
		int location_id = -1;
		bool has_item = false;

		for (int i =0; i < MAX_SLOTS; ++i)
		{
			if (inventory_item_list[i].item.getItemName() == name)
			{
				print ("found item, checking count");
				has_item = true;
				if (inventory_item_list[i].count >= count)
				{
					//only true if we have enough items as well
					print ("has enough items requested");
					location_id = i;
				}
				else
				{
					print ("not enough items requested");
				}
			} 

			//stop the loop, we are done
			if (has_item)
			{
				break;
			}
		}

		return location_id;
	}
		
}
