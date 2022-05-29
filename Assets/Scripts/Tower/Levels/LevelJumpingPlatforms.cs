using UnityEngine;

namespace Levels
{
    public class LevelJumpingPlatforms : Level
    {
        [SerializeField] private GameObject levelPlatform;

        internal override void OnEnter()
        {
            levelPlatform.SetActive(true);
        }

        internal override void OnExit()
        {
            levelPlatform.SetActive(false);
        }
    }
}