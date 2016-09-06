using UnityEngine;
using System.Collections;

public class Player : Character {

        
    //sprite things
    public Sprite spriteW, spriteD, spriteS;
    private bool facingUp;
    private bool facingDown;
    private bool facingLeft;
    private bool facingRight;

    //spellsuff
    public Rigidbody2D spell, spell1, spell2;
    public Transform topSpellSpawner;
    public Transform bottomSpellSpawner;
    public Transform leftSpellSpawner;
    public Transform rightSpellSpawner;


    //target
    public GameObject target;
    public bool mouseOnTarget;


    void Start ()
    {
        Lifeforce = 5476;        	    
	}

    sealed public override void Update()
    {        
        ResourceRegeneration();
        CheckDebuffs();
        Move();
        Controls();
        ChangeSprite();
	}

    void Move()
    {
        if(IsStunned == false)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizontal * MovementSpeed, moveVertical * MovementSpeed);

            if (Energy >= 5 && isSprinting == true)
            {
                Energy -= MaxEnergy / 100 * 5 * Time.deltaTime;
                MovementSpeed = MaxMovementSpeed;
            }
            else
            {
                isSprinting = false;
                MovementSpeed = BaseMovementSpeed;
            }
        }                       
    }

    public void SetTarget(GameObject targetSet)
    {
        target = targetSet;
    }

    public void Controls()
    {
        //left click
        if(Input.GetMouseButtonDown(0))
        {
            if(target != null && mouseOnTarget == false)
            {
                print("Clearing Target");
                target = null;
            }
        }
        if(IsStunned == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isSprinting = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isSprinting = false;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                spell = spell1;
                if (Mana >= spell.GetComponent<Spell>().spellCost && target != null)
                {
                    Mana -= spell.GetComponent<Spell>().spellCost;
                    Attack();
                }
                else if(target == null)
                {
                    print("You have no target");
                }
                else if (IsStunned == true)
                {
                    print("You are Stunned");
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                spell = spell2;
                if (Mana >= spell.GetComponent<Spell>().spellCost && target != null)
                {
                    Mana -= spell.GetComponent<Spell>().spellCost;
                    Attack();
                }
                else if (target == null)
                {
                    print("You have no target");
                }
                else if(IsStunned == true)
                {
                    print("You are Stunned");
                }                
            }
        }
        
    }

    public void CheckDebuffs()
    {
        if(IsStunned == true)
        {
            
        }
        if(IsSlowed == true)
        {
            MovementSpeed = BaseMovementSpeed / 2;
        }
        if(IsSnared == true)
        {

        }
    }

    void Attack()
    {
        if(facingUp == true)
        {
            Rigidbody2D spellInstance = Instantiate(spell, topSpellSpawner.transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
            spellInstance.GetComponent<Spell>().target = target;
            Physics2D.IgnoreCollision(spellInstance.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
        }
        else if(facingDown == true)
        {
            Rigidbody2D spellInstance = Instantiate(spell, bottomSpellSpawner.transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
            spellInstance.GetComponent<Spell>().target = target;
            Physics2D.IgnoreCollision(spellInstance.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
        }
        else if (facingLeft == true)
        {
            Rigidbody2D spellInstance = Instantiate(spell, leftSpellSpawner.transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
            spellInstance.GetComponent<Spell>().target = target;
            Physics2D.IgnoreCollision(spellInstance.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
        }
        else if(facingRight == true)
        {
            Rigidbody2D spellInstance = Instantiate(spell, rightSpellSpawner.transform.position, Quaternion.Euler(new Vector3(0, 0, 1))) as Rigidbody2D;
            spellInstance.GetComponent<Spell>().target = target;
            Physics2D.IgnoreCollision(spellInstance.GetComponent<Collider2D>(), this.gameObject.GetComponent<Collider2D>());
        }
        
    }
        
    void ChangeSprite()
    {
        if (Input.GetKey(KeyCode.W))
        {
            facingUp = true;
            facingLeft = false;
            facingRight = false;
            facingDown = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteW;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            facingUp = false;
            facingLeft = true;
            facingRight = false;
            facingDown = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteD;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            facingUp = false;
            facingLeft = false;
            facingRight = false;
            facingDown = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteS;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            facingUp = false;
            facingLeft = false;
            facingRight = true;
            facingDown = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteD;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }    
}
