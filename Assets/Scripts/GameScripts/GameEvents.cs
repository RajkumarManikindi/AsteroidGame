using System;
using UnityEngine;

namespace GameScripts
{
    public static class GameEvents
    {
        public static Action<Vector2, bool> AsteroidDestroyed;
        public static Action AsteroidCreated;
        public static Action PlayerDead;
        public static Action PlayerActivated;
        public static Action GameStarted;
        public static Action GameWin;
        public static Action GameLose;
    }
}