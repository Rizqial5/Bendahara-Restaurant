using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestBR.UI
{
    public class ShopObjectButton : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI itemName;
        [SerializeField] Image itemIcon;

        [TextArea(2,8)]
        [SerializeField] string descriptionTextContainer;

        
        public void SetObjectButton(string itemText, string descriptionText, Sprite shopIcon)
        {
            itemName.text = itemText;
            descriptionTextContainer = descriptionText;
            itemIcon.sprite = shopIcon;
        }

        


       
    }
}
