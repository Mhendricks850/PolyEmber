﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CraftingSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    Crafting craftingScript;
    Inventory inventory;

    public Collectible myItem;
    Image myIcon;

    private void Start()
    {
        inventory = GameObject.FindObjectOfType<Inventory>();

        if(myItem == null)
        {
            Destroy(gameObject);
        }
        craftingScript = GameObject.FindObjectOfType<Crafting>();
        myIcon = GetComponent<Image>();
        myIcon.sprite = myItem.icon;
        myIcon.preserveAspect = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        craftingScript.CraftItem(myItem);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (myItem != null)
        {
            inventory.ShowToolTip(myItem, true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        inventory.HideToolTip();
    }
}
