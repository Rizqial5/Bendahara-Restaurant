using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Core
{
    [CreateAssetMenu(fileName = "Shop", menuName = "ShopObject", order = 1)]
    public class ShopObjectSO : ScriptableObject
    {
        [SerializeField] string objectName;

        [TextArea(2, 8)]
        [SerializeField] private string descriptionText;

        public string GetObjectName()
        {  return objectName; }

        public string GetDescriptionText()
        { return descriptionText; }


    }
}
