using UnityEngine;

namespace Levels
{
    public class LevelPlateShooting : Level
    {
        [SerializeField] private Transform shootingPlates;

        private void Start()
        {
            ActivatePlates(false);
        }

        internal override void OnEnter() => ActivatePlates(true);

        internal override void OnExit() => ActivatePlates(false);

        private void ActivatePlates(bool value)
        {
            foreach (Transform plate in shootingPlates)
            {
                plate.gameObject.SetActive(value);
            }
        }
    }
}