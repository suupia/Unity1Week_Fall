using TMPro;
using UnityEngine;

namespace Projects.Utility
{
    public static class ScoreFormatter
    {
        public static TextMeshProUGUI FormatScore(TextMeshProUGUI scoreTMP, double amount)
        {
            if (amount >= 0)
            {
                scoreTMP.color = Color.black;
            }
            else
            {
                scoreTMP.color = new Color(132 / 255.0f, 17/ 255.0f, 17/ 255.0f);
            }

            scoreTMP.text = $"Score : {NumberFormatter.FormatNumber(amount)}";

            return scoreTMP;
        }
    }
}