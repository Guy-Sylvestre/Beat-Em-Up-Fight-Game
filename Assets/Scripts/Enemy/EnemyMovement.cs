using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Declaration de class exterieur
    private CharacterAnimation enemyAnim;
    
    
    //Declaration de variable private
    private Rigidbody myBody;
    private float chase_Player_After_Attack = 1f;
    private float current_Attack_Time;
    private float default_Attack_Time = 2f;
    private bool followPlayer, attackPlayer;
    private Transform playerTarget;

    //Declaration de variable public
    public float speed = 5f;
    public float attack_Distance = 1f;

    void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
    void Start()
    {
        followPlayer = true;
        current_Attack_Time = default_Attack_Time;
    }


    void Update()
    {
        Attack();
    }

    void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        //if we are not support to follow the player
        if (!followPlayer)
            return;

        if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance)
        {
            transform.LookAt(playerTarget);
            myBody.velocity =transform.forward * speed;

            if (myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= attack_Distance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }// fallow target


    void Attack()
    {
        //if we should NOT attack the player
        //Exit the function
        if (!attackPlayer)
            return;

        current_Attack_Time += Time.deltaTime;

        if(current_Attack_Time > default_Attack_Time)
        {
            enemyAnim.EnemyAttack(Random.Range(0, 3));
            current_Attack_Time = 0f;
        }

        if (Vector3.Distance(transform.position, playerTarget.position) > attack_Distance + chase_Player_After_Attack)
        {
            followPlayer = true;
            attackPlayer = false;
        }

    }// Attack enemy


}//class
