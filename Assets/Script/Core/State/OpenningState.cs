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
        }

        public override void ExitState()
        {
            Debug.Log("Toko tutup");

            planningMechanic.ActivePlanning();
        }

        public override void FrameUpdate()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                gameManager.gameStateMachine.ChangeState(gameManager.planningState);
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                openingMechanic.GetNpcSpawner().GenerateNPC();
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
