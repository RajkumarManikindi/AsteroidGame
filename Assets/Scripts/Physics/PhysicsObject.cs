using Interfaces;
using UnityEngine;

namespace Physics
{
    public class PhysicsObject<T> : MonoBehaviour
    {
        private T _cachedObj;
        public T SelfRigidBody { 
            get
            {
                if (_cachedObj == null)
                {
                    TryGetComponent(out _cachedObj);
                }
                return _cachedObj;
            }
        }
    
        private void OnTriggerEnter(Collider other)
        {
            OnCollision(other.gameObject);
        }
        private void OnCollisionEnter(Collision other)
        {
            OnCollision(other.gameObject);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnCollision(other.gameObject);
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollision(other.gameObject);
        }

         
        public virtual void OnCollision(GameObject collidedObject)
        {
        
        }
    }
}