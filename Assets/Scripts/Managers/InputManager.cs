using GameScripts;
using Interfaces;
using PlayerScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
        public class InputManager 
        {
                private readonly IController _controller;
                private readonly Player _player;
                private readonly SpaceGunsManager _spaceGunsManager;
                private readonly Animator _playerAnimator;
                private static readonly int Boost = Animator.StringToHash("Boost");
                
                public InputManager(IController gameController, Player player, Animator animator, SpaceGunsManager spaceGunsManager)
                { 
                        _controller = gameController;
                        _player = player;
                        _spaceGunsManager = spaceGunsManager;
                        _playerAnimator = animator;
                }
                

                public void SetUpEvents()
                {
                        _controller.ChangeGun += ChangeGun;
                        _controller.Shoot+= Shoot;
                        _controller.DirectionValue += Direction;
                        _controller.ThrustValue += Thrust;
                        _controller.Restart += Restart;
                }
                public void RemoveEvents()
                {
                        _controller.ChangeGun -= ChangeGun;
                        _controller.Shoot -= Shoot;
                        _controller.DirectionValue -= Direction;
                        _controller.ThrustValue -= Thrust;
                        _controller.Restart -= Restart;
                }

                private void Shoot()
                {
                        _spaceGunsManager.Shoot();
                }

                private void ChangeGun(int val)
                {
                        _spaceGunsManager.ChangeGun(val);
                        
                }

                private void Thrust(bool value)
                {
                        _player.ThrustValue = value;
                        _playerAnimator.SetBool(Boost, value);        
                         
                }
                
                private void Direction(float value)
                {
                        _player.DirectionValue = value;
                        
                }

                private void Restart()
                {
                        SceneManager.LoadScene(0);  
                }

                 
                

        }
}