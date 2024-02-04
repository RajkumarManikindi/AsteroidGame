using System.Collections.Generic;
using GameScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class UIManager :MonoBehaviour
    {
        [SerializeField] private GameObject lifeIcon;
        [SerializeField] private GameObject lifeIconLocation;
        [SerializeField] private GameObject restartGame;
        
        

        private readonly List<GameObject> _listIcons = new List<GameObject>();
        private void OnEnable()
        {
            GameEvents.PlayerDead += RefreshLifeCount;
            GameEvents.GameStarted += SetupLifeUI;
            GameEvents.GameWin += OnGameWin;
            GameEvents.GameLose += OnGameLose;

        }
        private void OnDisable()
        {
            GameEvents.PlayerDead -= RefreshLifeCount;
            GameEvents.GameStarted -= SetupLifeUI;
            GameEvents.GameWin -= OnGameWin;
            GameEvents.GameLose -= OnGameLose;
        }
        
        

        private void SetupLifeUI()
        {
            var totalImages = _listIcons.Count;
            if (totalImages < GameData.TotalLifeCount)
            {
                for (var i = totalImages; i < GameData.TotalLifeCount; i++)
                {
                    var ob=Instantiate(lifeIcon, lifeIconLocation.transform, true);
                    ob.transform.localScale = Vector3.one;
                    _listIcons.Add(ob);
                }
            }

        }

        private void RefreshLifeCount()
        {
            for (var i = 0; i < GameData.TotalLifeCount; i++)
            {
                _listIcons[i].SetActive(i < GameData.CurrentLifeCount);
            }
            
        }

        private void OnGameWin()
        {
            restartGame.SetActive(true);
        }

        private void OnGameLose()
        {
            restartGame.SetActive(true);
        }


        public void StartGame()
        {
            GameEvents.GameStarted?.Invoke();
            GameEvents.PlayerActivated?.Invoke();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

    }
}