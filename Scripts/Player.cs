using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] FightingCactus fightingCactus;

    InventarioManager m;
    [SerializeField] UI_Inventory       uiInventory;
    [SerializeField] PointCounter       pointCounter;                    
    [SerializeField] CameraFollow       cameraFollow;
    [SerializeField] float speed       = 20;
    [SerializeField] float maxSpeed    = 10;
    [SerializeField] float jumpPower   = 10;

                     bool movement     = true;
                     bool grounded;
                     bool jump;
                     bool doubleJump;

                     Rigidbody2D rb2d;
                     Animator anim;
                     Inventory inventory;



    void Awake()
    {    
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
        uiInventory.SetPlayer(this);
    }
    void Start()
    {
        m = GetComponent<InventarioManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fightingCactus.Injured(20f);
        }

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (grounded)
        {
            doubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                jump = true;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                jump = true;
                doubleJump = false;
            }
        }
    }
    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;
        if (grounded)
        {
            rb2d.velocity = fixedVelocity;        
        }
        else
        {
            h = 0;
        }

        if (!movement) h = 0;
       
        rb2d.AddForce(Vector2.right * speed * h);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (h > 0.1f)
        { 
            transform.localScale = new Vector3(0.18f, 0.18f, 0.18f);
            cameraFollow.drch = true;     
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-0.18f, 0.18f, 0.18f);
            cameraFollow.drch = false;
        } 

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    }
    void OnBecameInvisible()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            rb2d.velocity = new Vector3(0f, 0f, 0f);       
            transform.parent = collision.transform;
            grounded = true;
        }
        if (collision.gameObject.name == "Coin1")
        {
            pointCounter.IncreaseCoins(10);
            Destroy(collision.gameObject, 0.1f);
        }
        if (collision.gameObject.name == "Coin2")
        {
            pointCounter.IncreaseCoins(20);
            Destroy(collision.gameObject, 0.1f);
        }
        if (collision.gameObject.name == "Coin3")
        {
            pointCounter.IncreaseCoins(30);
            Destroy(collision.gameObject, 0.1f);
        }

    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (col.gameObject.tag == "Platform")
        {
            transform.parent = col.transform;
            grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }
        if (col.gameObject.tag == "Platform")
        {
            transform.parent = null;
            grounded = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();

        if(itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
        

        if (collision.GetComponent<InventarioObjetoRecogible>() != null)
        {
            InventarioObjetoRecogible i = collision.GetComponent<InventarioObjetoRecogible>();
            m.AgregarAlgoAlInventario(i.id, i.cantidad);
            Destroy(collision.gameObject);
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    void UseItem(Item item)
    {
        switch (item.itemType)
        {           
            case Item.ItemType.HealthPotion:
                Debug.Log("Nos hemos curado");
                // FlashGreen();
                inventory.RemoveItem(new Item { itemType = Item.ItemType.HealthPotion, amount = 1 });
                break;
            case Item.ItemType.ManaPotion:
                Debug.Log("Mana aumentando");
                // FlashBlue();
                inventory.RemoveItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
                break;
        }
    }
}
