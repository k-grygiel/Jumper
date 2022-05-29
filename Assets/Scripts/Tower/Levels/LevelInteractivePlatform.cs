using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
    public class LevelInteractivePlatform : Level
    {
        [SerializeField] private GameObject levelPlatform;
        [SerializeField] private BulletSpawner spawner;
        [SerializeField] private InteractivePlatformController interactivePlatform;

        internal override void OnEnter()
        {
            levelPlatform.SetActive(true);
            spawner.ResetSpawner();
            interactivePlatform.RestartPlatform();
        }

        internal override void OnExit()
        {
            levelPlatform.SetActive(false);
        }
    }
}