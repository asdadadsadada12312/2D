using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    public Transform itemSlotContainer;
    public Transform itemSlotTemlate;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemLishChanged;

        RefreshInventoryItems();
    }

    private void Inventory_OnItemLishChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemlate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 110f;
        foreach (Item item in inventory.GetItemsList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemlate,itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);


            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

          
            Button itemButton = itemSlotRectTransform.GetComponent<Button>();
            Button deleteButton = itemSlotRectTransform.Find("deleteButton").GetComponent<Button>();

          
            itemButton.onClick.AddListener(() =>
            {
              
                deleteButton.gameObject.SetActive(true);

                
                deleteButton.onClick.AddListener(() =>
                {
                    
                    inventory.RemoveItem(item);
                    RefreshInventoryItems();
                });
            });

           
            deleteButton.gameObject.SetActive(false);

            TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
            if(item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }
            x++;
            if(x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
}
