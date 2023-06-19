using System;
using System.Collections;
using System.Collections.Generic;
using Projects.GameSystem.Interfaces;
using UnityEngine;


namespace Projects.GameSystem.Scripts
{
    public class GameStateManager : IGameState
    {
        public GameState CurrentState { get; set; }
    }

    public class InGameStateManager : IGameState
    {
        public GameState CurrentState { get; set; } = GameState.Game;
    }
}