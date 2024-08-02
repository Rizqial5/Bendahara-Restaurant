using System.Collections;
using System.Collections.Generic;
using TestBR.Core;
using UnityEngine;

namespace TestBR.Planning
{
    public class ShopEffectActivator : MonoBehaviour
    {
        
        public void ActivateShopEffects(List<ShopObjectSO> inventoryShopObject)
        {
            
            foreach (ShopObjectSO item in inventoryShopObject)
            {
                item.ActivateEffect();
            }
        }
    }
}
