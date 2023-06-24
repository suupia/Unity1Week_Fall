using System.Collections;
using System.Collections.Generic;
using Projects.BGM.Scripts;
using Projects.GameSystem.Interfaces;
using Projects.GameSystem.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class RootLifeTimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);

        // GameSystem
        builder.Register<GameStateManagerManager>(Lifetime.Singleton).As<IGameStateManager>();
        
        // Music
        builder.Register<MusicVolumeContainer>(Lifetime.Singleton);
    }
}
