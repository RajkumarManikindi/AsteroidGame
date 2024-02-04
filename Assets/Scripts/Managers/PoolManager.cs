using System.Collections.Generic;
using System.Linq;
using GameScripts;
using SpriteScripts;
using UnityEngine;

namespace Managers
{
    public class PoolManager : MonoBehaviour
    {
     
        private static List<Bullet.Bullet> _poolBullets;
        private static List<Asteroid.Asteroid> _poolAsteroid;
        private SpriteManager _spriteManager;
        private void BulletPoolSetup(GameObject bulletPrefab, GameObject asteroidPrefab, SpriteManager spriteManager)
        {
            _spriteManager = spriteManager;
            _poolBullets = new List<Bullet.Bullet>();
            for (var j = 0; j < 50; j++)
            {
                var ob = Instantiate(bulletPrefab, Vector3.one * 1000, Quaternion.identity).AddComponent<Bullet.Bullet>();
                ob.transform.parent = this.transform;
                ob.gameObject.SetActive(false);
                _poolBullets.Add(ob);
            }

            _poolAsteroid = new List<Asteroid.Asteroid>();
            for (var j = 0; j < 30; j++)
            {
                var ob = Instantiate(asteroidPrefab, Vector3.one * 1000, Quaternion.identity).AddComponent<Asteroid.Asteroid>();
                ob.transform.parent = this.transform;
                ob.gameObject.SetActive(false);
                _spriteManager.SetSprite(ob.GetComponent<SpriteRenderer>(),"Asteroid");
                _poolAsteroid.Add(ob);
            }
        }

        public void SetupPoolManager(GameObject bullet, GameObject asteroidPrefab,SpriteManager _spriteManager)
        {
            if (bullet != null)
            {
                BulletPoolSetup(bullet, asteroidPrefab,_spriteManager);
            }
        }
        public static Bullet.Bullet GetBullet(float speed, float damageValue)
        {
            var bullet = _poolBullets.FirstOrDefault(i => !i.gameObject.activeInHierarchy);
            if (bullet != null)
            {
                bullet.BulletSpeed = speed;
                bullet.DamageValue = damageValue;
            }
            return bullet;
        }
        public static Asteroid.Asteroid GetAsteroid(float health, float damageValue, bool canSplit)
        {
            var asteroid = _poolAsteroid.FirstOrDefault(i => !i.gameObject.activeInHierarchy);
            if (asteroid != null)
            {
                asteroid.SetupAsteroid(health, damageValue, canSplit);
                GameEvents.AsteroidCreated?.Invoke();
            }
            return asteroid;
        }
    }
}