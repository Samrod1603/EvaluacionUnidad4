using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachinePlayer : MonoBehaviour
{
    PlayerMovement ScriptMovementPlayer;
    public int state;
    public int attackState;
    Attack scriptAttack;

    void Start()
    {
        ScriptMovementPlayer = GetComponent<PlayerMovement>();
        state = 1;
        attackState = 1;
        scriptAttack = GetComponent<Attack>();
    }

    void Update()
    {
        switch (state) 
        {
            case 1:
                ScriptMovementPlayer.Movement();
                attackState = 1;
                break;
            case 2:
                ScriptMovementPlayer.EnemyKnockback();
                PlayerMovement.Animator.SetBool("isKnocked", true);
                if (ScriptMovementPlayer.knockbackCounter <= 0)
                {
                    state = 1;
                    PlayerMovement.Animator.SetBool("isKnocked", false);
                }
                break;
            case 3:
                ScriptMovementPlayer.StayStill();
                break;
            case 4:
                ScriptMovementPlayer.JustDashed();
                break;

            case 5:                                                                     //SALE A LA DERECHA
                ScriptMovementPlayer.StayStill();
                ScriptMovementPlayer.RgidBody.velocity = Vector2.right * 6;
                ScriptMovementPlayer.transform.eulerAngles = new Vector3(0, 0, 0);
                break;

            case 6:                                                                    //SALE A LA IZQUIERDA
                ScriptMovementPlayer.StayStill();
                ScriptMovementPlayer.RgidBody.velocity = Vector2.right * -6;
                ScriptMovementPlayer.transform.eulerAngles = new Vector3(0, 180, 0);
                break;

            default:
                break;
        }

        switch (attackState)
        {
            case 1: // Attack
                scriptAttack.canAttack = true;
                break;
            case 2: // Cant Attack
                scriptAttack.canAttack = false;
                break;
            default:
                break;
        }
    }
}
