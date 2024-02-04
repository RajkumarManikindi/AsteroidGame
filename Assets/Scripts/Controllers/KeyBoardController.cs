using System;
using Interfaces;
using UnityEngine;

namespace Controllers
{
    public class KeyBoardController: MonoBehaviour,IController
    {
        public Action<int> ChangeGun { get; set; }
        public Action Shoot { get; set; }
    
        public Action<float> DirectionValue { get; set; }
        public Action<bool> ThrustValue { get; set; }
        public Action Restart { get; set; }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                ThrustValue?.Invoke(true);
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                ThrustValue?.Invoke(false);
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                DirectionValue?.Invoke(1);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                DirectionValue?.Invoke(-1f);
            } 
        
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                DirectionValue?.Invoke(0);
            }
        

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot?.Invoke();
            }
        
            if (Input.GetKeyDown(KeyCode.G))
            {
                ChangeGun?.Invoke(0);
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                ChangeGun?.Invoke(1);
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                ChangeGun?.Invoke(2);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart?.Invoke();
            }
            
        }


   
    }
}