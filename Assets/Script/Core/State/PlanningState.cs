using System.Collections;
using System.Collections.Generic;
using TestBR.Openning;
using TestBR.Planning;
using UnityEngine;

namespace TestBR.Core
{
    public class PlanningState : GameState
    {
        public PlanningState(GameManager gameManager, GameStateMachine gameStateMachine, PlanningMechanic planningMechanic, OpeningMechanic openingMechanic) : base(gameManager, gameStateMachine, planningMechanic, openingMechanic)
        {
        }

        public override void EnterState()
        {

            planningMechanic.GetMissionManager().GenerateMission();
            
        }

        public override void ExitState()
        {
            base.ExitState();

            planningMechanic.PlayOpening();

        }

        public override void FrameUpdate()
        {
            planningMechanic.GetMissionManager().CheckCompleteMission();

            if (Input.GetKeyDown(KeyCode.E))
            {
                planningMechanic.GetEffectActivator().ActivateEffect();
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
