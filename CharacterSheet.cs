using UnityEngine;
using System.Collections.Generic;

public class CharacterSheet : MonoBehaviour {


	public CharacterItemSlot helm_slot, shoulder_slot, ring1_slot, ring2_slot, neck_slot, chest_slot, pants_slot, gloves_slot, boots_slot, weapon_slot, offhand_slot;
	public GameObject character_sheet_object;


	//replace the current item with a new one, return the old item from the slot if something is already equipped


	void Update()
	{
		//if I is pressed disable//enable inventory
		if (Input.GetKeyDown(KeyCode.C))
		{
			character_sheet_object.SetActive(!character_sheet_object.activeSelf);
		}
	}
	//called on right click of an inventory slot item

	public void equipItem(Item item)
	{
		switch (item.getEquippedType())
		{

		//if we unequip successfully then set the item to this one
		case EquippableClass_e.HELM:
			if (helm_slot.unequipItem(item))
			{
				helm_slot.setItem (item);
			}
			break;
			
		case EquippableClass_e.SHOULDERS:
			if (shoulder_slot.unequipItem(item))
			{
				shoulder_slot.setItem (item);
			}
			break;

		case EquippableClass_e.CHEST:
			if (chest_slot.unequipItem(item))
			{
				chest_slot.setItem (item);
			}
			break;

		case EquippableClass_e.PANTS:
			if (pants_slot.unequipItem(item))
			{
				pants_slot.setItem (item);
			}
			break;

		case EquippableClass_e.NECKLACE:
			if (neck_slot.unequipItem(item))
			{
				neck_slot.setItem (item);
			}
			break;
		
		case EquippableClass_e.GLOVES:
			if (gloves_slot.unequipItem(item))
			{
				helm_slot.setItem (item);
			}
			break;

		case EquippableClass_e.BOOTS:
			if (boots_slot.unequipItem(item))
			{
				boots_slot.setItem (item);
			}
			break;

		case EquippableClass_e.OFFHAND:
			if (offhand_slot.unequipItem(item))
			{
				offhand_slot.setItem (item);
			}
			break;

		//*******************SPECIAL CASES **********************

		case EquippableClass_e.RING:
			//ring 1 is taken, and ring 2 is available
			if (ring1_slot.getItem().getItemName() != "" && ring2_slot.getItem().getItemName() == "")
			{
				ring2_slot.setItem (item);
				break;
			} 
			else //just do slot 1
			{
				if (ring1_slot.unequipItem (item))
				{
					ring1_slot.setItem (item);
				}
				break;
			}

		case EquippableClass_e.ONE_HAND_WEAPON:
			//if we have a 1h already equipped and no offhand, dual wield
			if (weapon_slot.getItem ().getEquippedType () == EquippableClass_e.ONE_HAND_WEAPON && offhand_slot.getItem ().getItemName () == "")
			{
				offhand_slot.setItem (item);
			} else if (offhand_slot.getItem ().getWeaponType () == WeaponClass_e.ORB ||
			         offhand_slot.getItem ().getWeaponType () == WeaponClass_e.TALISMAN ||
			         offhand_slot.getItem ().getWeaponType () == WeaponClass_e.QUIVER) //just replace the current weapon
			{
				//attempt to return all incompatible types to the inventory (talismans, orbs, quivers etc) then equip weapon in main slot

				//return main weapon to inventory
				if (weapon_slot.unequipItem (item))
				{
					//return offhand to inventory
					if (offhand_slot.unequipItem (item))
					{
						//replace main weapon
						weapon_slot.setItem (item);
					}

				}
			} else if (weapon_slot.unequipItem (item)) //just equip the weapon in the main slot
			{
				weapon_slot.setItem (item);
			}
			break;

		case EquippableClass_e.TWO_HAND_WEAPON:
			
			//if we have an offhand return it to the inventory
			if (offhand_slot.getItem ().getEquippedType() != EquippableClass_e.UNKNOWN) //just replace the current weapon
			{
				//return main weapon to inventory
				if (weapon_slot.unequipItem (item))
				{
					//return offhand to inventory
					if (offhand_slot.unequipItem (item))
					{
						//replace main weapon
						weapon_slot.setItem (item);
					}

				}
			} 
			else if (weapon_slot.unequipItem (item)) //just equip the weapon in the main slot
			{
				weapon_slot.setItem (item);
			}
			break;

		default:
			print ("something went wwrong when equipping the wepaon: UNKNOWN TYPE");
			break;
			
		}
	}
}
