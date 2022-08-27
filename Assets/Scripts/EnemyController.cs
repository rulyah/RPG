using System.Collections;
using Enums;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerController player;
    public GoldLoot goldLoot;
    public Animator animator;
    public float moveSpeed = 0.03f;
    public int health = 100;
    public EnemyState state;


    public void Explosion()
    {
        //player.health -= 20;
    }

    private void IdleState()
    {
    }

    private void ChaseState()
    {
        var direction = Vector3.Normalize(player.transform.position - transform.position);
        transform.position += direction * moveSpeed;
        transform.forward = direction.normalized;
    }

    private void PunchState()
    {
    }

    private void DeathState()
    {
    }

    public void DoDeath()
    {
        state = EnemyState.DEATH;
        StartCoroutine(Death());
    }

    public void DoIdle()
    {
        state = EnemyState.IDLE;
    }

    public void DoChase()
    {
        state = EnemyState.CHASE;
        animator.SetBool("MoveBool", true);

    }

    public void DoPunch()
    {
        state = EnemyState.PUNCH;
        animator.SetBool("MoveBool", false);
        StartCoroutine(Punch());
    }

    
    
    void Update()
    {
        switch (state)
        {
            case EnemyState.IDLE: 
                IdleState();
                break;
            case EnemyState.CHASE:
                ChaseState();
                break;
            case EnemyState.DEATH:
                DeathState();
                break;
            case EnemyState.PUNCH:
                PunchState();
                break;
        }

        if (state != EnemyState.DEATH)
        {
            if (health <= 0)
            {
                DoDeath();
            }
        }
        
        
        if (state == EnemyState.IDLE)
        {
            var distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 100)
            {
                DoChase();
            }
        }

        if (state == EnemyState.CHASE)
        {
            var distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance <= 1.0f)
            {
                DoPunch();
            }
        }
    }

    private IEnumerator Death()
    {
        animator.SetTrigger("DeathTriger");
        yield return new WaitForSeconds(1.0f);
        goldLoot.DropGold(transform.position);
        Destroy(gameObject);
    }
    private IEnumerator Punch()
    {
        animator.SetTrigger("PunchTriger");
        yield return new WaitForSeconds(0.1f);
        Explosion();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
