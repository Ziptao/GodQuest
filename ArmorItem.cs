using UnityEngine;
using System.Collections.Generic;

public class ArmorItem : Item 
{
	private EquippableClass_e m_armor_type = EquippableClass_e.UNKNOWN;


	//Constructor
	ArmorItem()
	{
		//get random armor type for the drop
		m_armor_type = determineArmorType();

	}


	//determine drop type based on tier
	private EquippableClass_e determineArmorType()
	{
		EquippableClass_e item = EquippableClass_e.UNKNOWN;
		//roll a random number between 1 and 10 for the pool to pull from, tier determines what types can drop
		int max_item_range = 9;
		if (m_item_tier <= 2)
		{
			max_item_range = 5;
		}
		else if (m_item_tier <= 4)
		{
			max_item_range = 8;
		}

		int seed = Random.Range(0, max_item_range);

		//common types 0-5
		//boots, gloves, pants, chest

		//uncommon types 6-8
		//Helm, Shoulders

		//rare types 9
		// rings, neck

		//more common item types
		if (seed < 6)
		{
			//roll for the type of slot
			seed = Random.Range (0, 3);
			switch (seed)
			{
			case 0:
				item = EquippableClass_e.BOOTS;
				m_equip_type = EquippableClass_e.BOOTS;
				break;
			case 1:
				item = EquippableClass_e.GLOVES;
				m_equip_type = EquippableClass_e.GLOVES;
				break;
			case 2:
				item = EquippableClass_e.PANTS;
				m_equip_type = EquippableClass_e.PANTS;
				break;
			case 3:
				item = EquippableClass_e.CHEST;
				m_equip_type = EquippableClass_e.CHEST;
				break;
			default:
				break;
			}
		} 
		//uncommon types
		else if (seed >= 6 && seed <= 8)
		{
			//roll for the type of slot
			seed = Random.Range (0, 1);
			switch (seed)
			{
			case 0:
				item = EquippableClass_e.HELM;
				m_equip_type = EquippableClass_e.HELM;
				break;
			case 1:
				item = EquippableClass_e.SHOULDERS;
				m_equip_type = EquippableClass_e.SHOULDERS;
				break;
			default:
				break;
			}
		}
		//rare higher tier types
		else if(seed == 9)
		{
			//roll for the type of slot
			seed = Random.Range (0, 1);
			switch (seed)
			{
			case 0:
				item = EquippableClass_e.RING;
				m_equip_type = EquippableClass_e.RING;
				break;
			case 1:
				item = EquippableClass_e.NECKLACE;
				m_equip_type = EquippableClass_e.NECKLACE;
				break;
			default:
				break;
			}
		}
		else //we dun fucked up
		{

		}

		return item;
	}
		
}
