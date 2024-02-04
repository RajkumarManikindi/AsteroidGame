using System;
using GameScripts;
using Physics;
using UnityEngine;

namespace PlayerScripts
{
    public class Player : PhysicsObject<Rigidbody2D>
    {
        private float _thrustForce;
        private float _turnSpeed;

        public bool ThrustValue { get; set; }
        public float DirectionValue { get; set; }

        private float _health;

        public static bool PlayerReadyForCollision;
        public static bool PlayerReadyForControl;

        private void OnEnable()
        {
            PlayerReadyForCollision = false;
            PlayerReadyForControl = true;
        }

        public void SetupPlayer(float thrustForce, float turnSpeed, float health)
        {
            _thrustForce = thrustForce;
            _turnSpeed = turnSpeed;
            _health = health;
        }

        private void FixedUpdate()
        {
            if(!PlayerReadyForControl)
                return;
            
            if (ThrustValue) {
                SelfRigidBody.AddForce(transform.up * _thrustForce);
            }
            if (DirectionValue != 0f) {
                SelfRigidBody.AddTorque(_turnSpeed * DirectionValue);
            }
        }

        public void TakeDamage(float value)
        {
            if(!PlayerReadyForCollision || _health < 0) return;
             
            _health -= value;
            if (_health < 0)
            {
                StopPhysics();
                OnPlayerDead();
            }
        }

        private void OnPlayerDead()
        {
            GameData.ReduceLives();
            if (GameData.CurrentLifeCount > 0)
            {
                Invoke(nameof(ActivatePlayer), 3);
            }
            else
            {
                GameEvents.GameLose?.Invoke();
            }

            GameEvents.PlayerDead?.Invoke();
        }

        private void StopPhysics()
        {
            PlayerReadyForControl = false;
            SelfRigidBody.velocity = Vector2.zero;
            SelfRigidBody.angularVelocity = 0;
            ThrustValue = false;
            DirectionValue = 0;
        }

        private void ActivatePlayer()
        {
            _health = 100;
            PlayerReadyForControl = true;
            GameEvents.PlayerActivated?.Invoke();
        }
        
    }
}
