using System.Collections;
using System.Collections.Generic;
using Projects.BGM.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class RootLifeTimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);

        // 子のLifetimeScopeに同じMusicVolumeContainerを引き渡す
        builder.Register<MusicVolumeContainer>(Lifetime.Singleton);
    }
}
