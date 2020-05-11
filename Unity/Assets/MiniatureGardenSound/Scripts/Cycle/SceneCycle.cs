using System;
using UnityEngine;

namespace MiniatureGardenSound.Cycle
{
    public class SceneCycle : MonoBehaviour
    {
        private void Awake()
        {
            // todo: transition処理
        }

        private void OnDestroy()
        {
            // transition抜け処理？ 非同期なら問題ないはず
        }
    }
}
