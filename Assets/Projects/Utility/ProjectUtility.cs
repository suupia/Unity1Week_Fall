using UnityEngine;

namespace Projects.Utility
{
    public static class ProjectUtility
    {
        public static Vector2  RandomVector2()
        {
            float angle = UnityEngine. Random.Range(0f, 2f * Mathf.PI);  // 0から2π（360度）の範囲でランダムな角度を取得
            Vector2 randomUnitVector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));  // 単位円上の点を求める
            return randomUnitVector;
        }
        
        public static Vector2  RandomDownVector2()
        {
            float angle = UnityEngine. Random.Range(- Mathf.PI, 0);  // 0から2π（360度）の範囲でランダムな角度を取得
            Vector2 randomUnitVector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));  // 単位円上の点を求める
            return randomUnitVector;
        }
    }
}