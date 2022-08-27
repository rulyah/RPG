using UnityEngine;

namespace Arrow
{
    public class PowerArrow : ArrowController
    {
        void Start()
        {
        
        }

        void Update()
        {
            transform.position += transform.forward * arrowSpeed * Time.deltaTime;

        }
    }
}
