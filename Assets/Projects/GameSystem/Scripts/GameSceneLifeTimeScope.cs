using System.Collections;
using System.Collections.Generic;
using Projects.BGM.Scripts;
using Level.Interfaces;
using Projects.Fruit.Interfaces;
using Projects.Fruit.Scripts;
using Projects.GameSystem.Interfaces;
using Projects.Ground.Scripts;
using Projects.Level.Scripts;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Projects.Stage.Scripts;
using Projects.Utility;
using Projects.Score.Interfaces;
using Projects.Score.Script;
using Projects.Timer.Scripts;
using Projects.SE.Scripts;


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
            builder.Register<GameStateManagerManager>(Lifetime.Singleton).As<IGameStateManager>();
            builder.Register<StageManager>(Lifetime.Singleton);

            // Fruits
            builder.Register<FruitFactory>(Lifetime.Singleton);
            builder.Register<FruitControllerLoader>(Lifetime.Singleton);
            builder.Register<FruitControllerBuilder>(Lifetime.Singleton);
            builder.Register<FruitSpawner>(Lifetime.Singleton);
            builder.Register<FruitCountLimiter>(Lifetime.Singleton);
            builder.Register<FruitTypeSelector>(Lifetime.Singleton);


            // Laser
            builder.Register<LaserCreator>(Lifetime.Singleton);
            builder.Register<LaserSpawner>(Lifetime.Singleton);

            // Score
            builder.Register<FruitScore>(Lifetime.Singleton).As<IFruitScore>();
            builder.Register<ScoreTextSpawner>(Lifetime.Singleton);

            // Timer
            builder.Register<StageTimer>(Lifetime.Singleton);

            // Level
            builder.Register<LevelManager>(Lifetime.Singleton).As<ILevelManager>();
            builder.Register<JudgeLevelUp>(Lifetime.Singleton);

            // BGM
            builder.RegisterComponentInHierarchy<BGMController>(); // ヒエラルキー上のMonoBehaviourを登録

            // SE
            builder.RegisterComponentInHierarchy<SEController>(); // ヒエラルキー上のMonoBehaviourを登録
            
            // Restart
            builder.RegisterComponentInHierarchy<RestartController>(); // ヒエラルキー上のMonoBehaviourを登録
        }
    }
}