using Interfaces;
using Managers;
using UnityEngine;

namespace Guns
{
    public class Gun : MonoBehaviour,IGun
    {

        public float speed;
        public float damageValue;
        public virtual IBullet GetBullet()
        {
            var bullet = PoolManager.GetBullet(speed, damageValue);
            bullet.gameObject.SetActive(true);
            if (bullet != null)
            {
                bullet.transform.position = this.transform.position;
            }
            return bullet;
        }

        public virtual void Shoot()
        {
            
        }
    }
}