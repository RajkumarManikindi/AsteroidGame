using GameScripts;
using UnityEngine;

namespace Position
{
    public class ClampPosition:MonoBehaviour
    {
        private void FixedUpdate()
        {
            if(!this.gameObject.activeInHierarchy)
                return;
            transform.position = Boundaries.ClampPositionWithVector2(transform.position);
        }
    }
}