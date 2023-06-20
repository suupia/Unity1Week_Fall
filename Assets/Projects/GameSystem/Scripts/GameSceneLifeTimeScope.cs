using System.Collections;
using System.Collections.Generic;
using Projects.Fruit.Interfaces;
using Projects.Fruit.Scripts;
using Projects.GameSystem.Interfaces;
using Projects.Ground.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Projects.Stage.Scripts;
using Projects.Utility;
using Projects.Score.Interfaces;
using Projects.Score.Script;


namespace Projects.GameSystem.Scripts
{
    public class GameSceneLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // IPrefabLoader
            builder.Register<PrefabLoaderFromResources<Sprite>>(Lifetime.Singleton).As<IPrefabLoader<Sprite>>()
                .WithParameter("folderPath", "Sprites/Fruits");
            builder.Register<PrefabLoaderFromResources<FruitController>>(Lifetime.Singleton)
                .As<IPrefabLoader<FruitController>>().WithParameter("folderPath", "Prefabs/Fruits");
            builder.Register<PrefabLoaderFromResources<LaserController>>(Lifetime.Singleton)
                .As<IPrefabLoader<LaserController>>().WithParameter("folderPath", "Prefabs/Lasers");
            
            // GameSystem
            builder.Register<InGameStateManager>(Lifetime.Singleton).As<IGameState>(); // ToDo: Tmp
            builder.Register<StageManager>(Lifetime.Singleton);
            
            // Fruits
            builder.Register<FruitFactory>(Lifetime.Singleton);
            builder.Register<FruitControllerLoader>(Lifetime.Singleton);
            builder.Register<FruitControllerBuilder>(Lifetime.Singleton);
            builder.Register<FruitSpawner>(Lifetime.Singleton);
            

            // Laser
            builder.Register<LaserCreator>(Lifetime.Singleton);
            builder.Register<LaserSpawner>(Lifetime.Singleton);
            
            // Score
            builder.Register<FruitFruitScore>(Lifetime.Singleton).As<IFruitScore>();
        }
    }
}