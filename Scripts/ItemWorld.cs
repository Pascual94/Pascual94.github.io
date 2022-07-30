using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class ItemWorld : MonoBehaviour
{
    TextMesh textMesh;
    Item item;
    SpriteRenderer spriteRenderer;
    new Light light;

    void Awake()
    {
        spriteRenderer  = GetComponent<SpriteRenderer>();
        light           = GetComponent<Light>();
        textMesh = transform.Find("text").GetComponent<TextMesh>();
    }
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;

    }
    
    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        light.color = item.GetColor();
        if(item.amount > 1)
        {
            textMesh.text = item.amount.ToString();
        }
        else
        {
            textMesh.text = (" ");
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        Vector3 randomDir = UtilsClass.GetRandomDir();

        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir * 5f, item);

        itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 5f, ForceMode2D.Impulse);

        return itemWorld;
    }
}
