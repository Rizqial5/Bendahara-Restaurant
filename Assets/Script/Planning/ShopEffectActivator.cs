using System.Collections;
using System.Collections.Generic;
using TestBR.Core;
using UnityEngine;

namespace TestBR.Planning
{
    public class ShopEffectActivator : MonoBehaviour
    {
        private ShopMechannic shopMechannic;

        Dictionary<ShopObjectSO, bool> totalActivatedShopObject;


        List<ShopObjectSO> totalShopObject;

        private void Awake()
        {
            shopMechannic = GetComponent<ShopMechannic>();

            totalActivatedShopObject = new Dictionary<ShopObjectSO, bool>();
        }


        public void BuildLookUpTableShop()
        {
            

            totalShopObject = shopMechannic.GetBuyedLists();

            

            if (totalShopObject == null)
            {
                print("Barang tidak ada ");
                return;
            }

            foreach (ShopObjectSO item in totalShopObject)
            {
                totalActivatedShopObject[item] = false;
            }
        }

        public void ActivateEffect()
        {
            
            BuildLookUpTableShop();

            foreach (ShopObjectSO item in totalShopObject)
            {

                if (totalActivatedShopObject[item] == true)
                {
                    print("Efek telah diaktivasi");
                    continue;

                }
                

                item.ActivateEffect();

                totalActivatedShopObject[item] = true;
            }



        }
    }
}
