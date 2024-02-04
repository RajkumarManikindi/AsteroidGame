using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpriteScripts
{
    public class SpriteManager 
    {
        private  SpritesDataBase _spritesDataBase;
        public SpriteManager(SpritesDataBase spritesDataBase)
        {
            _spritesDataBase = spritesDataBase;
        }
        
        public void SetSprite(SpriteRenderer targetObject, string keyName)
        {
            var sprite = GetSprite(keyName);
            targetObject.sprite = sprite;
        }
        
        
        private Sprite GetSprite(string key, int number)
        {
            var selectedSprites = GetAllSprites(key);
            if (selectedSprites != null && selectedSprites.Count > number)
            {
                return selectedSprites[number];
            }

            return null;
        }
        private Sprite GetSprite(string key)
        {

            var selectedSprites = GetAllSprites(key);
            if (selectedSprites != null)
            {
                return  selectedSprites[Random.Range(0,selectedSprites.Count)];
            }

            return null;
        }

        private List<Sprite> GetAllSprites(string key)
        {
            if (_spritesDataBase.listOfSprites.All(i => i.key != key))
            {
                Debug.LogError("No Sprites with the key - "+key);
                return null;
            }
            return _spritesDataBase.listOfSprites.First(i=>i.key ==key).sprites;
        }


    }

     
}
