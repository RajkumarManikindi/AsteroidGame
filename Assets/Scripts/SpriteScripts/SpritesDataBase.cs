using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpriteScripts
{
    [CreateAssetMenu(fileName = "SpritesDataBase", menuName = "ScriptableObjects/SpriteDataBase", order = 2)]
    public class SpritesDataBase : ScriptableObject
    {
        [SerializeField]
        public List<SpritesData> listOfSprites;
    }

    [Serializable]
    public class SpritesData
    {
        public string key;
        public List<Sprite> sprites;
    }
}