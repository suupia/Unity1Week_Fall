using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Interfaces;
using Projects.Fruit.Scripts;
using Projects.GameSystem.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Projects.Stage.Scripts;
using Projects.Utility;

namespace Projects.GameSystem.Scripts
{
    public class GameSceneLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Utility
            builder.Register<PrefabLoaderFromResources<Sprite>>(Lifetime.Singleton).As<IPrefabLoader<Sprite>>()
                .WithParameter("folderPath", "Sprites/Fruits");
            builder.Register<PrefabLoaderFromResources<FruitController>>(Lifetime.Singleton)
                .As<IPrefabLoader<FruitController>>().WithParameter("folderPath", "Prefabs/Fruits");
            
            // GameSystem
            builder.Register<InGameStateManager>(Lifetime.Singleton).As<IGameState>(); // ToDo: Tmp
            builder.Register<StageManager>(Lifetime.Singleton);
            
            // Fruits
            builder.Register<Apple>(Lifetime.Singleton).As<IFruit>(); // ToDo: Tmp
            builder.Register<FruitCreator>(Lifetime.Singleton);
            builder.Register<FruitSpawner>(Lifetime.Singleton);
        }
    }
}