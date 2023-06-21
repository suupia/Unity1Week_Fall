using System.Collections;
using System.Collections.Generic;
using Level.Interfaces;
using UnityEngine;
#nullable  enable

namespace Projects.Level.Scripts
{
    public class LevelManager : ILevelManager
    {
        public int CurrentLevel { get; private set; }

        public void LevelUp()
        {
            CurrentLevel++; 
            Debug.Log($"Level Up! Current Level: {CurrentLevel}");
        }
    }
}