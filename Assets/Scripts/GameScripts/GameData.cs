 
using UnityEngine;

namespace GameScripts
{
        public static class GameData
        {
                private static int _totalLifeCount;
                private static int _currentLifeCount;
                private static int _totalAsteroidCount;
                public static int CurrentLifeCount => _currentLifeCount;

                public static int TotalLifeCount => _totalLifeCount;

                public static int TotalAsteroidCount
                {
                        get => _totalAsteroidCount;
                        set => _totalAsteroidCount = value;
                }

                public static void SetTotalLifeCount(int totalLifeCount)
                {
                        _totalLifeCount = totalLifeCount;
                        _currentLifeCount = _totalLifeCount;
                }

                public static void ReduceLives(int value = 1)
                {
                        _currentLifeCount -= value;
                }

                public static void ReduceAsteroidCount(int value = 1)
                {
                        TotalAsteroidCount -= value;
                }

                public static void AddAsteroidCount(int value = 1)
                {
                        TotalAsteroidCount += value;
                }

                 

                public static void ResetValues()
                {
                        _currentLifeCount = 0;
                        _totalLifeCount = 0;
                        _totalAsteroidCount = 0;
                }

        }
}