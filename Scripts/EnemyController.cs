using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    CharacterStats stats;
   //public Transform Player;
   NavMeshAgent agent;
    Animator anim;
    public float attackRaduis= 5;


    bool canAttack = true;
    float attackCooldown = 1f;


    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();   
       anim = GetComponentInChildren<Animator>();
       stats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", agent.velocity.magnitude);
        float distance = Vector3.Distance(transform.position, LevelManager.instance.player.position);
        if (distance < attackRaduis)
        {
            agent.SetDestination(LevelManager.instance.player.position);
            if ( distance <= agent.stoppingDistance)
            {
                if (canAttack)
                {
                    StartCoroutine(cooldown());
                    anim.SetTrigger("Attack");

                }
            }
        }
    }

    IEnumerator cooldown()
    {
        canAttack= false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   Debug.Log("Player Contacted!");
            stats.ChangedHealth(other.GetComponentInParent<CharacterStats>().power);

            // Reduce Health
            Destroy(gameObject);
        } 
    }

    public void DamgePlayer()
    {
        LevelManager.instance.player.GetComponent<CharacterStats>().ChangedHealth(-stats.power);
    }
}
