using GameScripts;
using SpriteScripts;
using UnityEngine;

namespace Managers
{
    public class AsteroidSpawnManager : MonoBehaviour
    {
        private void OnEnable()
        {
            GameEvents.AsteroidDestroyed += CreateAsteroidAfterDamage;
        }

        private void OnDisable()
        {
            GameEvents.AsteroidDestroyed -= CreateAsteroidAfterDamage;
        }

        public void AddAsteroids(int numberOfAsteroid)
        {
            //Note: Can be randomised
            var randomPos = new Vector2(1000,1000);
            for (int i = 0; i < numberOfAsteroid; i++)
            {
                CreateAsteroid(Vector2.one, randomPos, true);
            }          
        }

        
        private void CreateAsteroid(Vector2 scale, Vector2 position, bool canSplit)
        {
            var asteroid = PoolManager.GetAsteroid(100, 1000, canSplit);
            asteroid.transform.localScale = scale;
            asteroid.transform.position =  position;
        }

        private void CreateAsteroidAfterDamage(Vector2 position, bool canSplit)
        {
            if (canSplit)
            {
                //Note: Can be added Random here
                CreateAsteroidPieces(2, position);
            }
        }

        void CreateAsteroidPieces(int number, Vector2 position)
        {
            for (int i = 0; i < number; i++)
            {
                CreateAsteroid(Vector3.one * 0.5f, position,false);
            }
        }

    }
}