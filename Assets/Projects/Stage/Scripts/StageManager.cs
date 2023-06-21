using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#nullable  enable

namespace Projects.Stage.Scripts
{
    public class StageManager
    {
        public float StageWidth => _stageWidth;
        public float PaddleWidth => _stageWidth - 1;
        public float HorizontalMargin => 0;
        float _stageWidth = 14;
    }

}
