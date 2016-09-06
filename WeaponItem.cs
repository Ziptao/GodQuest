using UnityEngine;
using System.Collections;

public class WeaponItem : Item
{
	private WeaponClass_e m_weapon_type = WeaponClass_e.UNKNOWN;

	WeaponItem()
	{
		m_weapon_type = determineWeaponType();
	}
		
	//roll the weapon type that dropped
	WeaponClass_e determineWeaponType()
	{
		WeaponClass_e item = WeaponClass_e.UNKNOWN;

		int seed = Random.Range (0, 13);


		switch(seed)
		{
		case 0:
			item = WeaponClass_e.BOW;
			m_equip_type = EquippableClass_e.CHEST;
			m_equip_type = EquippableClass_e.ONE_HAND_WEAPON;
			break;
		case 1:
			item = WeaponClass_e.ONE_HAND_AXE;
			m_equip_type = EquippableClass_e.ONE_HAND_WEAPON;
			break;
		case 2:
			item = WeaponClass_e.ONE_HAND_MACE;
			m_equip_type = EquippableClass_e.ONE_HAND_WEAPON;
			break;
		case 3:
			item = WeaponClass_e.ONE_HAND_SWORD;
			m_equip_type = EquippableClass_e.ONE_HAND_WEAPON;
			break;
		case 4:
			item = WeaponClass_e.ORB;
			m_equip_type = EquippableClass_e.OFFHAND;
			break;
		case 5:
			item = WeaponClass_e.QUIVER;
			m_equip_type = EquippableClass_e.OFFHAND;
			break;
		case 6:
			item = WeaponClass_e.SHIELD;
			m_equip_type = EquippableClass_e.OFFHAND;
			break;
		case 7:
			item = WeaponClass_e.STAFF;
			m_equip_type = EquippableClass_e.TWO_HAND_WEAPON;
			break;
		case 8:
			item = WeaponClass_e.TALISMAN;
			m_equip_type = EquippableClass_e.OFFHAND;
			break;
		case 9:
			item = WeaponClass_e.TWO_HAND_AXE;
			m_equip_type = EquippableClass_e.TWO_HAND_WEAPON;
			break;
		case 10:
			item = WeaponClass_e.TWO_HAND_MACE;
			m_equip_type = EquippableClass_e.TWO_HAND_WEAPON;
			break;
		case 11:
			item = WeaponClass_e.TWO_HAND_SWORD;
			m_equip_type = EquippableClass_e.TWO_HAND_WEAPON;
			break;
		case 12:
			item = WeaponClass_e.WAND;
			m_equip_type = EquippableClass_e.ONE_HAND_WEAPON;
			break;
		case 13:
			item = WeaponClass_e.XBOW;
			m_equip_type = EquippableClass_e.TWO_HAND_WEAPON;
			break;
		}

		return item;

	}

}
