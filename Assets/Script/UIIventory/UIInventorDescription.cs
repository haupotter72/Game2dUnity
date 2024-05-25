using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class UIInventorDescription : MonoBehaviour
    {
        public Image itemImage;
        public TMP_Text title;

        public TMP_Text description;

        private void Awake()
        {
            ResetDescription();
        }

        public void ResetDescription()
        {
            if (itemImage != null)
            {
                itemImage.gameObject.SetActive(false);
                title.text = "";
                description.text = "";
            }
           
        }

        public void SetDescription(Sprite sprite, string itemName, string itemDescription)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = sprite;
            title.text = itemName;
            description.text = itemDescription;
        }


    }
}