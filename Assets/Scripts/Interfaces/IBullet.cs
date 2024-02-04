

using UnityEngine;

namespace Interfaces
{
    public interface IBullet
    {
        float BulletSpeed{ get; set; }
        float DamageValue { get; set; }
        void OnCollision(GameObject gameObject);
        void AddForce(Vector2 direction);
        void ResetBullet();
        
    }
}