using UnityEngine;

namespace Arrow
{
    public class DirectionalArrow : ArrowController
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
