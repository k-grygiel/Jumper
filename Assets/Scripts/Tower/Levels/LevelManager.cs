using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Levels
{
    public class LevelManager : MonoBehaviour
    {
        private Level currentLevel;

        public void SetLevel(Level level)
        {
            if (currentLevel != null)
                currentLevel.OnExit();

            currentLevel = level;
            currentLevel.OnEnter();
        }
    }
}