using UnityEngine;

namespace GameScripts
{
    public static class Boundaries
    {
        public static float MinimumY { get; set; }
        public static float MaximumY { get; set; }
        public static float MinimumX { get; set; }
        public static float MaximumX { get; set; }

     

        public static void Setup()
        {
            var mainCamera = Camera.main;
            if ( mainCamera!= null)
            {
                var cameraPosition = mainCamera.transform.position;
                MinimumY = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, -cameraPosition.z)).y;
                MaximumY = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, -cameraPosition.z)).y;
                MinimumX = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, -cameraPosition.z)).x;
                MaximumX = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, -cameraPosition.z)).x;
            }
        }
    
        public static Vector3 ClampPositionWithVector2(Vector2 position)
        {
            var temp = position;
            temp.x = temp.x < MinimumX ? MaximumX: temp.x;
            temp.y = temp.y < MinimumY ? MaximumY: temp.y;
            temp.x = temp.x > MaximumX ? MinimumX: temp.x;
            temp.y = temp.y > MaximumY ? MinimumY: temp.y;
            return temp;
        }
    }
}