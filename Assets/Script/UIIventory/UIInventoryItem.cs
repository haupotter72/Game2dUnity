using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class UIInventoryItem : MonoBehaviour, IPointerClickHandler
    {
        public Image itemImage;
        public TMP_Text quantityTXT;

        public Image BoderImage;

        public event Action<UIInventoryItem> OnItemClicked, OnRightMouseBtnClick;

        private bool empty = true;


        private void Awake()
        {
            ResetData();
            Deselect();
        }

        public void ResetData()
        {
            if(itemImage != null)
            {
                itemImage.gameObject.SetActive(false);
                empty = true;
            }
            
        }

        public void Deselect()
        {
            if(BoderImage)
            {
                 BoderImage.enabled = false;
            }
           
        }

        public void SetData(Sprite sprite, int quantity)
        {
            if (itemImage != null)
            {
                itemImage.gameObject.SetActive(true);
                itemImage.sprite = sprite;
                quantityTXT.text = quantity + "";
                empty = false;
            }
        }

        public void Select()
        {
            BoderImage.enabled = true;
        }

        public void OnPointerClick(PointerEventData pointerData)
        {

            if (pointerData.button == PointerEventData.InputButton.Right)
            {
                OnRightMouseBtnClick?.Invoke(this);
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
        }


    }
}