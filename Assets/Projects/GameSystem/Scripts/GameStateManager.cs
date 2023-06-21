using System;
using System.Collections;
using System.Collections.Generic;
using Projects.GameSystem.Interfaces;
using Projects.Timer.Scripts;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using VContainer;

namespace Projects.GameSystem.Scripts
{
    public class GameStateManagerManager : IGameStateManager
    {
        public GameState CurrentState { get; private set; }

        
        public GameStateManagerManager( )
        {
            CurrentState = GameState.Title;
        }
        
        public void ChangeState(GameState state)
        {
            CurrentState = state;
        }
        

    }

    /// <summary>
    /// 常にGameState.Gameを返すクラス
    /// </summary>
    public class InGameStateManager : IGameStateManager
    {
        public GameState CurrentState { get; set; } = GameState.Game;
        public void ChangeState(GameState state)
        {
            CurrentState = state;
        }
    }
}