using System.Collections.Generic;
using Guns;
using Interfaces;
using PlayerScripts;
using UnityEngine;

namespace Managers
{
        public class SpaceGunsManager: MonoBehaviour
        {
                private IGun _currentSpaceGun;
                private List<IGun> _listOfSpaceGuns;
                
                
                public void Awake()
                {
                        LoadAllGuns();
                        ChangeGun();
                        
                }
                
                private void LoadAllGuns()
                {
                        _listOfSpaceGuns = new List<IGun>();
                
                        var singleSpaceGun = new GameObject("SingleBulletGun").AddComponent<SingleBulletGun>();
                        singleSpaceGun.damageValue = 30;
                        singleSpaceGun.speed = 300;
                        singleSpaceGun.transform.parent = transform;
                        _listOfSpaceGuns.Add(singleSpaceGun);
                
                        var doubleSpaceGun = new GameObject("DoubleBulletGun").AddComponent<DoubleBulletGun>();
                        doubleSpaceGun.transform.parent = transform;
                        doubleSpaceGun.damageValue = 40;
                        doubleSpaceGun.speed = 300;
                        _listOfSpaceGuns.Add(doubleSpaceGun);
                
                        var tripleSpaceGun = new GameObject("TripleBulletGun").AddComponent<TripleBulletGun>();
                        tripleSpaceGun.transform.parent = transform;
                        tripleSpaceGun.damageValue = 50;
                        tripleSpaceGun.speed = 300;
                        _listOfSpaceGuns.Add(tripleSpaceGun);
                }
                
                public void ChangeGun(int value = 0)
                {
                        if (Player.PlayerReadyForControl)
                        {
                                if (value >= 0 && value < _listOfSpaceGuns.Count)
                                {
                                        _currentSpaceGun = _listOfSpaceGuns[value];
                                }       
                        }
                }

                public void Shoot()
                {
                        if (Player.PlayerReadyForControl)
                        {
                                _currentSpaceGun.Shoot();
                        }
                }

                
        }
}