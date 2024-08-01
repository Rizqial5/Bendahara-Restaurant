using System.Collections;
using System.Collections.Generic;
using TestBR.Openning;
using TestBR.Planning;
using UnityEngine;

namespace TestBR.Core
{
    public class OpenningState : GameState
    {
        public OpenningState(GameManager gameManager, GameStateMachine gameStateMachine, PlanningMechanic planningMechanic, OpeningMechanic openingMechanic) : base(gameManager, gameStateMachine, planningMechanic, openingMechanic)
        {
        }

        public override void EnterState()
        {
            base.EnterState();

            openingMechanic.GetDayTimer().SetStartHour(8);
            openingMechanic.GetDayTimer().TimeDisplay();

            //Effect Activation
        }

        public override void ExitState()
        {
            Debug.Log("Toko tutup");

            openingMechanic.GetDayTimer().AddDay();

            openingMechanic.GetDayTimer().SetOpen();
            planningMechanic.ActivePlanning();
        }

        public override void FrameUpdate()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                openingMechanic.GetDayTimer().SetIsClosed(true);
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                openingMechanic.GetNpcSpawner().GenerateNPC();
            }

            if(openingMechanic.GetResourcesDatabase().CheckResources(StatsEnum.FoodIngredients))
            {
                openingMechanic.GetDayTimer().SetIsClosed(true);
            }


            openingMechanic.GetDayTimer().TimeStart();

            if(openingMechanic.GetDayTimer().GetIsClosed())
            {
                gameManager.gameStateMachine.ChangeState(gameManager.planningState);
            }


        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
