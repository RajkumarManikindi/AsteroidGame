using GameScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _playerAnimator;
        private static readonly int Activated = Animator.StringToHash("PlayerActivated");
        private static readonly int Dead = Animator.StringToHash("PlayerDead");

        private void OnEnable()
        {
            TryGetComponent(out _playerAnimator);
            SetEventRegisters();
        }

        private void OnDisable()
        {
            RemoveEventRegisters();
        }

        private void SetEventRegisters()
        {
            GameEvents.PlayerActivated += PlayerActivated;
            GameEvents.PlayerDead += PlayerDead;
        }

        private void RemoveEventRegisters()
        {
            GameEvents.PlayerActivated -= PlayerActivated;
            GameEvents.PlayerDead -= PlayerDead;
        }

        private void PlayerActivated()
        {
            if (_playerAnimator != null)
            {
                Player.PlayerReadyForCollision = false;
                _playerAnimator.SetTrigger(Activated);
            }
        }

        private void PlayerDead()
        {
            if (_playerAnimator != null)
            {
                Player.PlayerReadyForCollision = false;
                _playerAnimator.SetTrigger(Dead);
            }
        }

        private void OnStartAnimationFinish()
        {
            Player.PlayerReadyForCollision = true;
        }
    }
}
