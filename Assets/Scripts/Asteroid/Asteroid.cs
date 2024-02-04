using GameScripts;
using Interfaces;
using Physics;
using PlayerScripts;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Asteroid
{
    public class Asteroid: PhysicsObject<Rigidbody2D> ,IObstacle
    {
        private float Health { get; set; }
        private float _randomRotationSpeed;
        private const float RandomMovementSpeed = 0.4f;
        private float _damageValue = 1000;
        private bool _canSplit = true;
       


        public void SetupAsteroid(float health, float damageValue,bool canSplit)
        {
            this.gameObject.SetActive(true);
            Health = health;
            _canSplit = canSplit;
            _damageValue = damageValue;
            _randomRotationSpeed = RandomRotationSpeed();
            SetRandomPath(RandomDirection() * RandomMovementSpeed);
        }

        public void TakeDamage(float value)
        {
            Health -= value;
            if (Health > 0) return;
            GameEvents.AsteroidDestroyed?.Invoke(transform.position, _canSplit);
            ResetAsteroid();
        }
    
        private Vector2 RandomDirection()
        {
            return Random.insideUnitCircle.normalized;
        }
        private float RandomRotationSpeed()
        {
            return Random.Range(30, 65);
        }

        void Update()
        {
            transform.Rotate(0,0,_randomRotationSpeed * Time.deltaTime);
        }

        private void SetRandomPath(Vector2 direction)
        {
            SelfRigidBody.AddForce(direction * _randomRotationSpeed);
        }

        private void ResetAsteroid()
        {
            this.gameObject.SetActive(false);
            transform.position = Vector3.one * 1000;
            transform.localScale = Vector3.one;
            SelfRigidBody.velocity = Vector2.zero;
            SelfRigidBody.angularVelocity = 0;
        }

        public override void OnCollision(GameObject collidedObject)
        {
            var collidedObj = collidedObject.transform.GetComponent<Player>();
            if (collidedObj!= null)
            {
                collidedObj.TakeDamage(_damageValue);  
            }
        
        }




    }
}