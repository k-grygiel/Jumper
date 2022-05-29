using Target;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour, ITarget
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerShooter playerShooter;
        [SerializeField] private PlayerInteraction playerInteraction;
        
        [Space(20)]
        [SerializeField] private Transform startingPosition;

        private PlayerMovementInput inputActions;

        public void Kill()
        {
            ResetPosition();
        }

        public void ResetPosition()
        {
            transform.position = startingPosition.position;
        }

        private void Awake()
        {
            inputActions = new PlayerMovementInput();
            inputActions.Enable();
            playerMovement.Init(inputActions);
            playerShooter.Init(inputActions);
            playerInteraction.Init(inputActions);
        }
    }
}