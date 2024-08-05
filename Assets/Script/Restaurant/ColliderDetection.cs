using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.NPC;

namespace TestBR.Restaurant
{
    public class ColliderDetection : MonoBehaviour
    {

        [SerializeField] AttractMechanic attractMechanic;

       
        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "NPC")
            {
                if (collision.GetComponent<NpcController>().GetNpcIsDone()) return;

                if (attractMechanic.GetResourcesDatabase().CheckResources(Core.StatsEnum.FoodIngredients)) return;

                if(attractMechanic.CheckProbability())
                {
                    print(collision.name + " Masuk Restaurant");

                    collision.GetComponent<NpcMover>().SetTarget(attractMechanic.GetRestoPosition());


                } else if(!attractMechanic.CheckProbability())
                {
                    print("Ndak jadi masuk");
                }
            }
        }
    }

}