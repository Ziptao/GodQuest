using UnityEngine;
using System.Collections.Generic;

public enum WeaponClass_e
{
	ONE_HAND_SWORD, TWO_HAND_SWORD,
	ONE_HAND_AXE, TWO_HAND_AXE,
	ONE_HAND_MACE, TWO_HAND_MACE,
	WAND, STAFF, TALISMAN, SHIELD, ORB,
	BOW, XBOW, QUIVER, UNKNOWN
}

public enum ItemType_e
{
	ARMOR, WEAPON, CONSUMABLE, QUEST, KEY, MATERIAL, UNKNOWN
}

public enum EquippableClass_e
{
	HELM, SHOULDERS, CHEST, GLOVES, PANTS, BOOTS, RING, NECKLACE, ONE_HAND_WEAPON, OFFHAND, TWO_HAND_WEAPON, UNKNOWN
}
	
public enum MiscClass_e
{
	HELAING_POTION, RESISTANCE_POTION, STAMINA_POTION, MANA_POTION, HASTE_POTION, UNKNOWN
}

public class Item  {

	protected string m_name;
	protected ItemType_e m_type;
	public Sprite m_icon_sprite;
	protected bool m_stackable;
	public EquippableClass_e m_equip_type = EquippableClass_e.UNKNOWN;
	public WeaponClass_e m_weapon_type = WeaponClass_e.UNKNOWN;


	public Item()
	{


	}
		
	public string getItemName()
	{
		return m_name;
	}

	public void setName(string name)
	{
		m_name = name;
	}

	public EquippableClass_e getEquippedType()
	{
		return m_equip_type;
	}

	public WeaponClass_e getWeaponType()
	{
		return m_weapon_type;
	}

	public bool isStackable()
	{
		return m_stackable;
	}

	public Sprite getSprite()
	{
		return m_icon_sprite;
	}

	public void setItemEquipType(EquippableClass_e type)
	{
		m_equip_type = type;
	}
		
}
	
