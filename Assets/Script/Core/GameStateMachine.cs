using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestBR.Core
{
    public class GameStateMachine : MonoBehaviour
    {
        public GameState currentGameState { get; set; }
        
        public void Initialize(GameState startingState)
        {
            currentGameState = startingState;

            currentGameState.EnterState();
        }

        public void ChangeState(GameState newState)
        {
            

            currentGameState.ExitState();

            currentGameState = newState;

            currentGameState.EnterState();
        }

    }
}
