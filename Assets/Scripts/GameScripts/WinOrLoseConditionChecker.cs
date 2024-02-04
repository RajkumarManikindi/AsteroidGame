using System;
using UnityEngine;

namespace GameScripts
{
    public class WinOrLoseConditionChecker : MonoBehaviour
    {
        private void Start()
        {
            
        }

        private void OnEnable()
        {
            GameEvents.AsteroidCreated += AsteroidCreated;
            GameEvents.AsteroidDestroyed += AsteroidDestroyed;
        }

        private void OnDisable()
        {
            GameEvents.AsteroidCreated -= AsteroidCreated;
            GameEvents.AsteroidDestroyed -= AsteroidDestroyed;
        }

        void AsteroidCreated()
        {
            GameData.AddAsteroidCount();
        }

        void AsteroidDestroyed(Vector2 vector2, bool canSplit)
        {
            GameData.ReduceAsteroidCount();
            if (GameData.TotalAsteroidCount <= 0)
            {
                GameEvents.GameWin?.Invoke();
            }
        }
    }
}