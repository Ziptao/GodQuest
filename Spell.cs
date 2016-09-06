using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    public Sprite spellSprite;
    public int spellDamage;
    public float spellVelocity;
    public int dotDuration, stunDuration, slowDuration;    
    public float spellCost;
    public float castTime;
    public bool dot;    
    public bool stun;
    public bool slow;
    public bool snare;


    public GameObject target;
   


        
    void Start()
    {
       
    }

    void Update()
    {
        if(target != null)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, spellVelocity * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }        
    }

    void OnCollisionEnter2D(Collision2D other)
    {       
		
		if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Player> () != null )
		{            
			other.gameObject.GetComponent<Player> ().TakeDamage (spellDamage);
		} 
		else if (other.gameObject.tag == "NPC" && other.gameObject.GetComponent<NPC> () != null )
		{
			other.gameObject.GetComponent<NPC>().TakeDamage(spellDamage);
		}
		if (other.gameObject.GetComponent<Debuffs> () != null)
		{

			if (dot == true)
			{
				other.gameObject.GetComponent<Debuffs>().DamageOverTime(spellDamage, dotDuration);

			}
			if (stun == true)
			{
				other.gameObject.GetComponent<Debuffs>().TimedStun(stunDuration);

			}
			if (slow == true)
			{
				other.gameObject.GetComponent<Debuffs>().TimedSlow();

			}
			if(snare == true)
			{

			}

			Destroy(this.gameObject);
		}
    }    
}
