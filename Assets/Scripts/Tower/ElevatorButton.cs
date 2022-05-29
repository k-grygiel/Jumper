using UnityEngine;
using Useables;

namespace Tower
{
    public class ElevatorButton : MonoBehaviour, IUseable
    {
        [SerializeField] private ElevatorController elevator;
        [SerializeField] private Transform floor;

        public void Use()
        {
            elevator.GoToFloor(floor);
        }
    }
}