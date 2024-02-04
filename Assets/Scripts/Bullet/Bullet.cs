using Interfaces;
using Physics;
using UnityEngine;

namespace Bullet
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet: PhysicsObject<Rigidbody2D>,IBullet
    {
        public float BulletSpeed{ get; set; }
        public float DamageValue { get; set; }
    
     
    
        public override void OnCollision(GameObject collidedObject)
        {
            var collidedObj = collidedObject.GetComponent<IObstacle>();
            collidedObj?.TakeDamage(DamageValue);
            ResetBullet();
        }

        public void AddForce(Vector2 direction)
        {
            SelfRigidBody.AddForce(BulletSpeed * direction);
        }

        public void ResetBullet()
        {
            SelfRigidBody.velocity = Vector2.zero;
            SelfRigidBody.angularVelocity = 0;
            transform.position = Vector3.one * 1000;
            gameObject.SetActive(false);
        }
    }
}