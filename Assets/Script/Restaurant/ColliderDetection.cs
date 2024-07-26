using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestBR.NPC;

namespace TestBR.Restaurant
{
    public class ColliderDetection : MonoBehaviour
    {

        AttractMechanic attractMechanic;

        private void Awake()
        {
            attractMechanic = GetComponentInParent<AttractMechanic>();
        }
        // Start is called before the first frame update
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "NPC")
            {
                if (collision.GetComponent<NpcController>().GetNpcIsDone()) return;

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