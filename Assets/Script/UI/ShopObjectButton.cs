using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace TestBR.UI
{
    public class ShopObjectButton : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI itemName;

        [TextArea(2,8)]
        [SerializeField] string descriptionTextContainer;


        public void SetObjectButton(string itemText, string descriptionText)
        {
            itemName.text = itemText;
            descriptionTextContainer = descriptionText;
        }


       
    }
}
