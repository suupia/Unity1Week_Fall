using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI platformText;
    void Start()
    {
        // プラットフォームの判定
        if (Application.isMobilePlatform)
        {
            // モバイル端末の場合の処理
            Debug.Log("This is a mobile device");
            // ここにモバイル端末の処理を記述する
            platformText.text = "Mobile";
        }
        else
        {
            // PC端末の場合の処理
            Debug.Log("This is a PC device");
            // ここにPC端末の処理を記述する
            platformText.text = "PC";
        }
    }
    
}
