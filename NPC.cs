using UnityEngine;
using System.Collections;

public class NPC : Character {
    
    
    public GameObject target;
    public Vector2 spawnPosition;    
    public float chaseDistance;
    public float minimumAttackDistance;
    public float maximumAttackDistance;
    public bool returningToPosition;

    public bool isMerchant;        

    
    void Start()
    {
        spawnPosition = transform.position;
        Lifeforce = 9125;        
    }


    sealed public override void Update()
    {
        if(isAlive == true)
        {
            if (target != null && Vector2.Distance(spawnPosition, transform.position) < chaseDistance)
            {
                MoveToEnemy();
                Attack();
            }
            else
            {
                MoveToSpawn();
            }
            ResourceRegeneration();
            CheckDebuffs();
            Die();
        }        
    }    

    public void SetLoot()
    {
        //set sprite to dead sprite
        //set loot in loot window        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && returningToPosition != true)
        {
            target = other.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && returningToPosition != true)
        {
            target = other.gameObject;
        }
    }

    public void MoveToEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, MovementSpeed * Time.deltaTime);
    }

    public void MoveToSpawn()
    {
        transform.position = Vector2.MoveTowards(transform.position, spawnPosition, MovementSpeed * Time.deltaTime);
        target = null;
        returningToPosition = true;        
        if (Vector2.Distance(spawnPosition, transform.position) <= 0)
        {
            returningToPosition = false;            
        }
    }

    public void Attack()
    {
        if(Vector2.Distance(spawnPosition, transform.position) < minimumAttackDistance)
        {
            //attack
        }
    }

    
}
