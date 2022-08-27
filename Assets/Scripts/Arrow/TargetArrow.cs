using UnityEngine;

namespace Arrow
{
    public class TargetArrow : ArrowController
    {
        private EnemyController enemy;
        private bool _isFlying;
    
        public void Shoot(EnemyController obj)
        {
            enemy = obj;
            _isFlying = true;
        }
    
        private void HitEnemy()
        {
            enemy.health -= damage;
        }
    
        void Start()
        {
        
        }

        void Update()
        {
            if (_isFlying)
            {   
                var distance = Vector3.Distance(enemy.transform.position, transform.position);
                if (distance <= 0.1f)
                {
                    _isFlying = false;
                    HitEnemy();
                    return;
                }
                var direction = Vector3.Normalize(enemy.transform.position - transform.position);
                transform.position += direction * arrowSpeed * Time.deltaTime;
            }
        }
    }
}
