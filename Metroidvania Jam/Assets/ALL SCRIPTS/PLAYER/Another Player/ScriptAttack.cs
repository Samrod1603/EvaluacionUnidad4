using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAttack : MonoBehaviour
{
    /*public int PlayerDamage;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public GameObject enemy;
    FirstEnemy ScriptEnemy;
    public bool canAttack;
    StateMachinePlayer statemachine;
    public bool canInteract;

    void Start()
    {
        ScriptEnemy = enemy.GetComponent<FirstEnemy>();
        PlayerDamage = 20;
        canAttack = true;
        statemachine = GetComponent<StateMachinePlayer>();
        canInteract = true;
    }

    void Update()
    {
        if (canAttack == true && Input.GetKeyDown(KeyCode.X))
        {
            PlayerAttack();
            // sonido de ataque
            // animación de ataque
            Debug.Log("you just attacked");
        }

        if (canInteract == true && canAttack == false && Input.GetKeyUp(KeyCode.X))
        {
            Interact();
        }
    }

    public void PlayerAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("just hit " + enemy.name);
            ScriptEnemy.TakeDamage(PlayerDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

    public void Interact()
    {

    }
    */
}
