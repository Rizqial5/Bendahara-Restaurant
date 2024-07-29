using System.Collections;
using System.Collections.Generic;
using TestBR.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestBR.UI
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField] private GameObject shopPanelUI;
        [SerializeField] private GameObject shopObjectButton;
        [SerializeField] private Transform shopPanelTransform;

        [Header("Show Component")]
        [SerializeField] TextMeshProUGUI showItemName;
        [SerializeField] TextMeshProUGUI showItemDesc;

        [SerializeField] ShopObjectSO[] shopObjectSOs;


        private List<GameObject> spawnedShopObjects;

        public void ShopButton()
        {
            if (shopPanelUI.activeInHierarchy)
            {
                
                foreach (GameObject item in spawnedShopObjects)
                {
                    Destroy(item);
                }


                spawnedShopObjects.Clear();

                shopPanelUI.SetActive(false);

                
                return;
            }

            shopPanelUI.SetActive(true);

            GenerateShopLists();
        }


        public void GenerateShopLists()
        {
            spawnedShopObjects = new List<GameObject>();

            foreach (ShopObjectSO shopItem in shopObjectSOs)
            {
                GameObject spawnObject = Instantiate(shopObjectButton, shopPanelTransform);

                spawnObject.GetComponent<ShopObjectButton>().SetObjectButton(shopItem.GetObjectName(), shopItem.GetDescriptionText());

                spawnObject.GetComponent<Button>().onClick.AddListener(() => { ShowButton(shopItem.GetObjectName(), shopItem.GetDescriptionText()); });  


                spawnedShopObjects.Add(spawnObject);
            }
            

        }

        public void ShowButton(string itemName, string itemDescription)
        {

            showItemName.text = itemName;
            showItemDesc.text = itemDescription;    

        }
    }
}
