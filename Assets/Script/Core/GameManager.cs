using System.Collections;
using System.Collections.Generic;
using TestBR.Openning;
using TestBR.Planning;
using UnityEngine;

namespace TestBR.Core
{
    public class GameManager : MonoBehaviour
    {
        public GameStateMachine gameStateMachine { get; set; }
        public PlanningState planningState { get; set; }
        public OpenningState openningState { get; set; }



        private PlanningMechanic planningMechanic;
        private OpeningMechanic openingMechanic;



        

        private void Awake()
        {
            planningMechanic = GetComponent<PlanningMechanic>();
            openingMechanic = GetComponent<OpeningMechanic>();


            gameStateMachine = new GameStateMachine();
            planningState = new PlanningState(this, gameStateMachine, planningMechanic, openingMechanic);
            openningState = new OpenningState(this, gameStateMachine, planningMechanic, openingMechanic);


           

        }

        private void Start()
        {
            gameStateMachine.Initialize(planningState);
        }

        private void Update()
        {
            gameStateMachine.currentGameState.FrameUpdate();
        }

        private void FixedUpdate()
        {
            gameStateMachine.currentGameState.PhysicsUpdate();
        }

        public void OpenningButton()
        {
            gameStateMachine.ChangeState(openningState);
        }

        

    }
}