using UnityEngine;

namespace Levels
{
    public abstract class Level : MonoBehaviour
    {
        [field: SerializeField] public LevelManager LevelManager { get; set; }

        internal abstract void OnEnter();

        internal abstract void OnExit();

        public virtual void Enter()
        {
            LevelManager.SetLevel(this);
        }
    }
}