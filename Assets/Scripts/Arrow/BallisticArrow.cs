using UnityEngine;

namespace Arrow
{
    public class BallisticArrow : ArrowController
    {
        public Rigidbody rigidbody;
        public Vector3 firstPos;

        public void HitEnemy(EnemyController obj)
        {
            obj.health -= damage;
        }

        public void Fire()
        {
            rigidbody.AddForce(transform.forward*arrowSpeed * Time.deltaTime,ForceMode.Impulse);
        }
        void Start()
        {
            firstPos = transform.position;
       
        }

        void Update()
        {
            if(!canDamage) return;
            var secondPos = transform.position;
            if (Physics.Raycast(transform.position, -transform.forward, out var hit,
                    Vector3.Distance(secondPos, firstPos)))
            {
                firstPos = secondPos;
                if (hit.transform.CompareTag("Enemy"))
                {
                    HitEnemy(hit.transform.GetComponent<EnemyController>());
                    canDamage = false;
                }
            }
        }
    }
}
