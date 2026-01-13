using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInputHandler _inputHandler;
        [SerializeField] private PlayerMotor _motor;
        [SerializeField] private ThirdPersonCamera _camera;
        [SerializeField] private PlayerAnimator _animator;

        private void Awake()
        {
            _camera.FollowTarget(transform);
        }

        private void Update()
        {
            HandleMovement();
            HandleAimInput();
            HandleInteraction();
            HandleLookDeltaInput();
        }

        public void HandleMovement()
        {
            Vector2 moveInput = _inputHandler.GetSmoothedMoveVector();
            _motor.Move(moveInput, Camera.main);
            _animator.SetMoveDirection(moveInput);
        }

        public void HandleAimInput()
        {
            bool isAiming = _inputHandler.IsAiming();
            _animator.SetIsAiming(isAiming);
            // _camera.BlendToFPS() — позже
        }

        public void HandleInteraction()
        {
            if (_inputHandler.IsInteractPressed())
            {
                GlobalEventBus.OnInteractRequested?.Invoke();
            }
        }


        public void HandleLookDeltaInput()
        {
            Vector2 lookDelta = _inputHandler.GetLookDelta();
            _camera.HandleLookInput(lookDelta);
        }


    }
}
