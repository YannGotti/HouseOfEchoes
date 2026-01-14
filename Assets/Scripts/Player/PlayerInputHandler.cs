using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private Vector2 movementInput;
        private bool isAiming;
        private bool isInteract;
        private bool isShooting;
        private bool isReloading;
        private Vector2 lookDelta;


        [SerializeField] private float _inputSmoothTime = 0.3f;

        private Vector2 _currentInput;
        private Vector2 _inputVelocity;

        public void AimingHandler(InputAction.CallbackContext context) => isAiming = context.ReadValueAsButton();
        public void MoveVectorHandler(InputAction.CallbackContext context) => movementInput = context.ReadValue<Vector2>();
        public void InteractHandler(InputAction.CallbackContext context) => isInteract = context.ReadValueAsButton();
        public void LookDeltaHandler(InputAction.CallbackContext context) => lookDelta = context.ReadValue<Vector2>();
        public void ShootingHandler(InputAction.CallbackContext context) => isShooting = context.ReadValueAsButton();
        public void ReloadHandler(InputAction.CallbackContext context) => isReloading = context.ReadValueAsButton();



        public Vector2 GetMoveVector() { return movementInput; }
        public Vector2 GetSmoothedMoveVector()
        {
            _currentInput = Vector2.SmoothDamp(_currentInput, movementInput, ref _inputVelocity, _inputSmoothTime);

            return Vector2.ClampMagnitude(_currentInput, 1f);
        }
        public bool IsAiming() { return isAiming; }
        public bool IsShooting() { return isShooting; }
        public bool IsReloading() { return isReloading; }
        public bool IsInteractPressed() { return isInteract; }
        public Vector2 GetLookDelta() { return lookDelta; }
    }
}
