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
        [SerializeField] Image adImageLocation;


        [SerializeField] private GameObject shopPanelUI;
        [SerializeField] private NotifSystem notifSystem;

        
        [Header("Show Component")]
        [SerializeField] TextMeshProUGUI showItemName;
        [SerializeField] TextMeshProUGUI showItemDesc;
        [SerializeField] TextMeshProUGUI showItemPrice;
        [SerializeField] TextMeshProUGUI showItemEffects;
        [SerializeField] TextMeshProUGUI showMaintenanceCost;

        [SerializeField] TextMeshProUGUI effecItemsTextPrefab;

        private PlanningMechanic planningMechanic;
        private ShopEffectActivator shopEffectActivator;


        private List<GameObject> spawnedShopObjects;
        private float tempPrice;
        private ShopObjectSO tempShopObject;

        private List<ShopObjectSO> buyedShopList;
        private List<string> itemEffectDescs;
        private List<string> itemNegativeEffectDescs;
        private List<TextMeshProUGUI> spawnedItemEffects;


        private int buyedSession;

        private void Start()
        {
            planningMechanic = FindAnyObjectByType<PlanningMechanic>();

            showItemName.text = "";
            showItemDesc.text = "";
            showItemPrice.text = "";
            showMaintenanceCost.text = "";
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

                spawnObject.GetComponent<ShopObjectButton>().SetObjectButton(shopItem.GetObjectName(), shopItem.GetDescriptionText(), shopItem.GetIcon());

                spawnObject.GetComponent<Button>().onClick.AddListener(() => { ShowButton(shopItem); });
                

                spawnedShopObjects.Add(spawnObject);
            }


        }

        public void ShowButton(ShopObjectSO shopObject)
        {

            showItemName.text = shopObject.GetObjectName();
            showItemDesc.text = shopObject.GetDescriptionText();
            showItemPrice.text = "Harga : " + shopObject.GetPrice().ToString();
            
            showMaintenanceCost.text = "Maintenance Cost : " + shopObject.GetMaintenanceCost().ToString();

            if(itemEffectDescs != null)
            {
                itemEffectDescs.Clear();
            }

            itemEffectDescs = shopObject.GetShopEffectsDescription();
            itemNegativeEffectDescs = shopObject.GetShopNegativeEffectsDescription();


            ShowItemEffects(itemEffectDescs, itemNegativeEffectDescs);

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
                

                notifSystem.StartNotif("Pilih item dulu");
                return;
            }

            if(!planningMechanic.GetResourcesDatabase().CheckCanBuy(StatsEnum.Gold, -tempPrice))
            {
                print("Uang masih kurang");

                notifSystem.StartNotif("Uang Masih Kurang");

                return;
            }

            if(buyedShopList.Contains(tempShopObject))
            {
                print("Barang sudah dibeli");

                notifSystem.StartNotif("Barang sudah dibeli");
                return;
            }

            if(buyedSession == 1)
            {
                notifSystem.StartNotif("Per hari maksimal beli " + buyedSession + " kali");
                return;
            }

            planningMechanic.GetResourcesDatabase().AddTotalSource(StatsEnum.Gold, -tempPrice);


            buyedShopList.Add(tempShopObject);

            tempShopObject.SetTimerEffect();
            tempShopObject.SetMaintenanceCost();
            tempShopObject.ActivateEffect();

            buyedSession++;

            adImageLocation.sprite = tempShopObject.GetAdImage();

            
        }

        public void ActivateShopEffects()
        {
            if (buyedShopList == null) return;

            shopEffectActivator = GetComponent<ShopEffectActivator>();

            shopEffectActivator.ActivateShopEffects(buyedShopList);
        }

        public void ShowItemEffects(List<string> effectDescs, List<string> negativeEffects)
        {
            

            if (spawnedItemEffects != null)
            {
                foreach (TextMeshProUGUI item in spawnedItemEffects)
                {
                    Destroy(item.gameObject);
                }

                spawnedItemEffects.Clear();
            }


            spawnedItemEffects = new List<TextMeshProUGUI>();

            foreach (string item in effectDescs)
            {
                TextMeshProUGUI spawnedText = Instantiate(effecItemsTextPrefab, showItemEffects.transform);

                spawnedText.text = item;

                spawnedItemEffects.Add(spawnedText);
                
            }

            if (negativeEffects == null) return;
            foreach (string item in negativeEffects)
            {
                TextMeshProUGUI spawnedText = Instantiate(effecItemsTextPrefab, showItemEffects.transform);

                spawnedText.text = item;
                spawnedText.color = Color.red;

                spawnedItemEffects.Add(spawnedText);
            }


        }

        public void ResetBuyedSession()
        { buyedSession = 0; }

        public List<ShopObjectSO> GetBuyedLists()
        { return buyedShopList; }

        private void OnDisable()
        {
            foreach (ShopObjectSO item in shopObjectSOs)
            {
                item.ResetValues();
            }
        }
    }
}
