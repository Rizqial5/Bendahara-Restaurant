using System.Collections;
using System.Collections.Generic;
using TestBR.Core;
using TestBR.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestBR.Planning
{
    public class ShopMechannic : MonoBehaviour
    {

        [SerializeField] ShopObjectSO[] shopObjectSOs;
        [SerializeField] GameObject shopObjectButton;
        [SerializeField] Transform shopPanelTransform;


        [SerializeField] private GameObject shopPanelUI;

        
        [Header("Show Component")]
        [SerializeField] TextMeshProUGUI showItemName;
        [SerializeField] TextMeshProUGUI showItemDesc;
        [SerializeField] TextMeshProUGUI showItemPrice;



        private PlanningMechanic planningMechanic;
        private ShopEffectActivator shopEffectActivator;


        private List<GameObject> spawnedShopObjects;
        private float tempPrice;
        private ShopObjectSO tempShopObject;

        private List<ShopObjectSO> buyedShopList;

        

        private void Start()
        {
            planningMechanic = FindAnyObjectByType<PlanningMechanic>();

            showItemName.text = "";
            showItemDesc.text = "";
            showItemPrice.text = "";
        }
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

                spawnObject.GetComponent<Button>().onClick.AddListener(() => { ShowButton(shopItem); });


                spawnedShopObjects.Add(spawnObject);
            }


        }

        public void ShowButton(ShopObjectSO shopObject)
        {

            showItemName.text = shopObject.GetObjectName();
            showItemDesc.text = shopObject.GetDescriptionText();
            showItemPrice.text = "Harga : " + shopObject.GetPrice().ToString();


            tempPrice = shopObject.GetPrice();
            tempShopObject = shopObject;
        }



        public void BuyButton()
        {
            if(buyedShopList == null)
            {
                buyedShopList = new List<ShopObjectSO>();
            }

            if(tempShopObject == null)
            {
                print("Pilih item dulu");
                return;
            }

            if(!planningMechanic.GetResourcesDatabase().CheckCanBuy(StatsEnum.Gold, -tempPrice))
            {
                print("Uang masih kurang");

                return;
            }

            if(buyedShopList.Contains(tempShopObject))
            {
                print("Barang sudah dibeli");
                return;
            }

            planningMechanic.GetResourcesDatabase().AddTotalSource(StatsEnum.Gold, -tempPrice);


            buyedShopList.Add(tempShopObject);
            tempShopObject.SetMaintenanceCost();

            
        }

        public void ActivateShopEffects()
        {
            if (buyedShopList == null) return;

            shopEffectActivator = GetComponent<ShopEffectActivator>();

            shopEffectActivator.ActivateShopEffects(buyedShopList);
        }

        public List<ShopObjectSO> GetBuyedLists()
        { return buyedShopList; }

        
    }
}
