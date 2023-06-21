using TMPro;
using UnityEngine;

namespace Projects.Score.Script
{
    
    public enum FruitScoreType
    {
        Positive,
        Negative
    }
    [RequireComponent(typeof(TextMeshPro))]
    public class FruitScoreTextController : MonoBehaviour
    {
        [SerializeField] Color positiveColor;
        [SerializeField] Color negativeColor;

        readonly float _lifeTime = 1f;
        
        public void Init(FruitScoreType type, string text)
        {
            Debug.Log($"Init FruitScoreTextController");
            var color = type == FruitScoreType.Positive ? positiveColor : negativeColor;
            var textMeshPro = GetComponent<TextMeshPro>();
            textMeshPro.text = text;
            textMeshPro.color = color;
            Destroy(gameObject, _lifeTime);
        }
        
    }
}