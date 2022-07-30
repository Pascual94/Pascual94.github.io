using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class UI_Inventory : MonoBehaviour
{
    Player player;
    Inventory inventory;
    Transform itemSlotContainer;
    Transform itemSlotTemplate;

    void Awake()
    {

        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        //RefreshInventoryItems();
    }

    void Start()
    {
        RefreshInventoryItems();
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 85f;
        foreach(Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            Text uiText = itemSlotRectTransform.Find("text").GetComponent<Text>();
            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                 if (item.Colocable())
                 {
                     Debug.Log("Seleccionamos objeto colocable");
                 }
                 if(!item.Colocable())
                 {
                     Debug.Log("Usamos el elemento");
                     inventory.UseItem(item);

                 }
                 // Use item
                 //inventory.UseItem(item);

            };

            itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () => 
            {
                // Drop item
                Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
                inventory.RemoveItem(item);
                ItemWorld.DropItem(player.GetPosition(), duplicateItem);
            };
            
            if (item.amount > 1)
            {
                uiText.text = item.amount.ToString();
            }
            else
            {
                uiText.text = " ";
            }
            x++;
            if(x > 2)
            {
                x = 0;
                y++;
            }
        }
    }

    void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }
}
