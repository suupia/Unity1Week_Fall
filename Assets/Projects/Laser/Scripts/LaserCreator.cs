using Projects.Fruit.Scripts;
using Projects.Utility;
using UnityEngine;

namespace Projects.Ground.Scripts
{
    public class LaserCreator
    {
        readonly IPrefabLoader<LaserController> _laserLoader;
        public LaserCreator(IPrefabLoader<LaserController> laserLoader)
        {
            _laserLoader = laserLoader;
        }
        public LaserController Create()
        {
            var laserObj = _laserLoader.Load("Laser");
            return laserObj;
        }
    }
}