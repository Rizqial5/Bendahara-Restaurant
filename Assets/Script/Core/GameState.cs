using System.Collections;
using System.Collections.Generic;
using TestBR.Planning;
using TestBR.Openning;
using UnityEngine;

namespace TestBR.Core
{
    public class GameState 
    {
        protected GameStateMachine gameStateMachine;
        protected GameManager gameManager;
        protected PlanningMechanic planningMechanic;
        protected OpeningMechanic openingMechanic;

        public GameState(GameManager gameManager   , GameStateMachine gameStateMachine, PlanningMechanic planningMechanic, OpeningMechanic openingMechanic)
        {
            this.gameManager = gameManager;
            this.gameStateMachine = gameStateMachine;
            this.planningMechanic = planningMechanic;
            this.openingMechanic = openingMechanic;
        }

        public virtual void EnterState() { }
        public virtual void ExitState() { }
        public virtual void FrameUpdate() { }
        public virtual void PhysicsUpdate() { }
    }
}
