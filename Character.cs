using UnityEngine;
using System.Collections;

public enum Faction_e
{
    NEUTRAL, FRIENDLY, HOSTILE
}

public class Character : MonoBehaviour {

    //character miscellaneous
    private Faction_e m_faction;
    public string m_firstName;
    public string m_lastName;

    //character stats
    public float m_age;
    public float ageRate = 1f;
    public float m_lifeforce;
    public float m_health;
    public float m_maxHealth; 
    public float m_mana;
    public float m_maxMana;
    public float m_spentMana;
    public float m_manaRegenRate;
    public float m_energy;
    public float m_maxEnergy;
    public float m_baseMovementSpeed = 5;
    public float m_movementSpeed;
    public float m_maxMovementSpeed = 10;

    //spell effects
    private bool m_isStunned = false;
    private bool m_isSnared = false;
    public bool m_isSlowed = false;

    //status effects
    public bool isAlive = true;
    public bool isBleeding;
    public bool isCasting;
    public bool isSprinting;    
    public bool immuneToDamage;
    public bool immuneToStun;
    public bool immuneToSlow;
    public bool immuneToSnare;
    



    public virtual void Update()
    {

    }

    public void ResourceRegeneration()
    {                
        if(isAlive == true)
        {
            m_age = m_lifeforce / 365;

            m_lifeforce += ageRate * Time.deltaTime;
            if (m_lifeforce % 365 == 0)
            {
                m_age++;
                print(m_age);
            }
        }

        if (m_health < m_maxHealth)
        {
            if(isBleeding == false)
            {
                m_health += m_maxHealth / 100 * 1.5f * Time.deltaTime;
            }            
        }
        if (m_mana < m_maxMana)
        {
            if(isCasting == false)
            {
                m_mana += m_maxMana / 100 * m_manaRegenRate * Time.deltaTime;
            }            
        }
        if (m_energy < m_maxEnergy)
        {
            if(isSprinting == false)
            {
                m_energy += m_maxEnergy / 100 * 1.5f * Time.deltaTime;
            }            
        }
    }

    public Faction_e Faction
    {
        get
        {
            return m_faction;
        }

        set
        {
            m_faction = value;
        }
    }

    public string FirstName
    {
        get
        {
            return m_firstName;
        }

        set
        {
            m_firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return m_lastName;
        }

        set
        {
            m_lastName = value;
        }
    }

    public float Age
    {
        get
        {
            return m_age;
        }

        set
        {
            m_age = value;
        }
    }

    public float Lifeforce
    {
        get
        {
            return m_lifeforce;
        }

        set
        {                   
            m_lifeforce = value;            
        }
    }

    public float Health
    {
        get
        {
            return m_health;
        }
        
        set
        {
            m_health = value;
        }
    }

    public float MaxHealth
    {
        get
        {
            return m_maxHealth;
        }

        set
        {
            m_maxHealth = value;
        }
    }

    public float Mana
    {
        get
        {
            return m_mana;
        }

        set
        {
            m_mana = value;
        }
    }

    public float MaxMana
    {
        get
        {
            return m_maxMana;
        }

        set
        {
            m_maxMana = value;
        }
    }

    public float SpentMana
    {
        get
        {
            return m_spentMana;
        }

        set
        {
            m_spentMana = value;
        }
    }

    public float ManaRegenRate
    {
        get
        {
            return m_manaRegenRate;
        }

        set
        {
            m_manaRegenRate = value;
        }
    }

    public float Energy
    {
        get
        {
            return m_energy;
        }

        set
        {
            m_energy = value;
        }
    }

    public float MaxEnergy
    {
        get
        {
            return m_maxEnergy;
        }

        set
        {
            m_maxEnergy = value;
        }
    }

    public float BaseMovementSpeed
    {
        get
        {
            return m_baseMovementSpeed;
        }

        set
        {
            m_movementSpeed = value;
        }
    }

    public float MovementSpeed
    {
        get
        {
            return m_movementSpeed;
        }

        set
        {            
            if(m_movementSpeed >= m_maxMovementSpeed)
            {
                m_movementSpeed = m_baseMovementSpeed;
            }          
            else
            {
                m_movementSpeed = value;
            }            
        }
    }

    public float MaxMovementSpeed
    {
        get
        {
            return m_maxMovementSpeed;
        }

        set
        {
            m_maxMovementSpeed = value;
        }
    }

    public bool IsStunned
    {
        get
        {
            return m_isStunned;
        }

        set
        {
            m_isStunned = value;
        }
    }

    public bool IsSnared
    {
        get
        {
            return m_isSnared;
        }

        set
        {
            m_isSnared = value;
        }
    }

    public bool IsSlowed
    {
        get
        {
            return m_isSlowed;
        }

        set
        {            
            m_isSlowed = value;                      
        }
    }

    public void TakeDamage(int damage)
    {
        if(immuneToDamage == false)
        {
            Health -= damage;
        }
        else
        {
            print("Immune to Damage");
        }       
    }           
}
