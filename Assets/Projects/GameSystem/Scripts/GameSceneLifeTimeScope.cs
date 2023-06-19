using System.Collections;
using System.Collections.Generic;
using GameSystem.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameSystem.Scripts
{
    public class GameSceneLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {

            builder.Register<InGameStateManager>(Lifetime.Singleton).As<IGameState>();
            builder.Register<StageManager>(Lifetime.Singleton);
        }
    }
}

