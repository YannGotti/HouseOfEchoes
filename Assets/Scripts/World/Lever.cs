using Assets.Scripts.Core.Interfaces;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.World
{
    public class Lever : MonoBehaviour, IInteractable
    {
        public string puzzleId;
        public void Interact(PlayerController player) 
        {
        }
    }
}
