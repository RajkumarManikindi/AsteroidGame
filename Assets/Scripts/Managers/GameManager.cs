
using Controllers;
using GameScripts;
using Interfaces;
using PlayerScripts;
using SpriteScripts;
using UnityEngine;


namespace Managers
{
     public class GameManager : MonoBehaviour
     {
     
          private IController _keyBoardController;
          private InputManager _inputManager;

          [SerializeField] private GameObject playerShip;
          [SerializeField] private GameObject bulletPrefab;
          [SerializeField] private GameObject asteroidPrefab;
          [SerializeField] private SpritesDataBase spritesDataBase;
          
           

          private void OnEnable()
          {
               //Setup GameData
               GameData.ResetValues();
               GameData.SetTotalLifeCount(2);
               
          }

          private void Start()
          {
               //Static Boundaries setup
               Boundaries.Setup();
          
               //Setup SpriteDataBase
               var spriteManager = new SpriteManager(spritesDataBase);

               //Adding GameCondition checker
               new GameObject("GameConditionChecker").AddComponent<WinOrLoseConditionChecker>();
               
               //For KeyBoard Setup
               var gameController = new GameObject("KeyBoardController");
               _keyBoardController = gameController.AddComponent<KeyBoardController>();
          
          
               //Create PoolManager
               var poolManager = new GameObject("PoolManager").AddComponent<PoolManager>();
               poolManager.SetupPoolManager(bulletPrefab, asteroidPrefab, spriteManager);
          
          
               //For Player Setup
               var player = Instantiate(playerShip).AddComponent<Player>();
               player.name = "Player";
               player.SetupPlayer(3, 2f, 100);
              
               


               //SpaceGun Setup
               var spaceGun = new GameObject("SpaceGunManager").AddComponent<SpaceGunsManager>();
               spaceGun.transform.parent = player.transform;


               var playerAnimator = player.GetComponent<Animator>();
               
               //For Input ManagerSetup
               _inputManager = new InputManager(_keyBoardController, player, playerAnimator, spaceGun);
               _inputManager.SetUpEvents();
          
          
               //Setup Asteroid Spawner Manager
               var asteroidSpawnManager = new GameObject("AsteroidSpawnManager").AddComponent<AsteroidSpawnManager>();
               //Note asteroid count can be changed 
               asteroidSpawnManager.AddAsteroids(3);
               
               
                
          }


          
          private void OnDestroy()
          {
               _inputManager.RemoveEvents();
          }

          
     }
}