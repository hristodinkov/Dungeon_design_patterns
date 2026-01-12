using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

namespace DungeonCrawler.Enemy.FSM
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyFSM : MonoBehaviour
    {
        //[SerializeField]
        //private Transform target;
        //private NavMeshAgent navMeshAgent;
        //private EnemyController enemyController;
        //[SerializeField]
        //private Collider attackCollider;
        //[SerializeField]
        //private float chaseRange = 3f;
        //[SerializeField]
        //private float chaseThreshold = 1f;
        //[SerializeField]
        //private float attackRange = 1.5f;
        //[SerializeField]
        //private float rotateSpeed = 90f;
        //[SerializeField]
        //private float idleTime = 2f;
        //[SerializeField]
        //private float attackTime = 0.5f;
        //[SerializeField]
        //private Animator animator;

        //private MoveState moveState;
        //private AlignToState alignToState;
        //private AttackState attackState;
        //private IdleState idleState;
        //private DeathState deathState;

        //// The current state
        //[SerializeReference]
        //private State currentState;

    

        //// Start is called once before the first execution of Update after the MonoBehaviour is created
        //void Start()
        //{
        //    navMeshAgent = GetComponent<NavMeshAgent>();
        //    enemyController = GetComponent<EnemyController>();

        //    //Create states
        //    moveState = new MoveState(target, navMeshAgent, chaseThreshold, chaseRange);
        //    alignToState = new AlignToState(transform, target, rotateSpeed, attackRange);
        //    idleState = new IdleState(chaseRange, transform, target, idleTime);
        //    attackState = new AttackState(attackTime,navMeshAgent,attackCollider);
        //    deathState = new DeathState(navMeshAgent,enemyController);

        //    //Transitions setup

        //    //While idling:
        //    //if a target is in range, transition to moveToState to chase the target.
        //    idleState.transitions.Add(new Transition(idleState.IsTargetInRange, moveState));

        //    //While moving to the target:
        //    //1. If the target is reached, transition to alignToState to align to the target.
        //    //2. If the target is out of range, transition to idle state.
        //    moveState.transitions.Add(new Transition(moveState.TargetReached, alignToState));
        //    moveState.transitions.Add(new Transition(moveState.TargetOutOfRange, idleState));

        //    //While aligning to the target:
        //    //If the target is out of range, transition to moveToState to chase the target again.
        //    alignToState.transitions.Add(new Transition(alignToState.TargetOutOfRange, moveState));
        //    alignToState.transitions.Add(new Transition(alignToState.AlignedWithTarget, attackState));
        //    //todo: add another transition to alignToState so that when the zombie aligns to the player,
        //    //transitions to attack state.


        //    attackState.transitions.Add(new Transition(attackState.AttackOver, idleState));

        //    //todo: add a transition to attackState so that when the attack is over, transitions to
        //    //alignToState.

        //    idleState.transitions.Add(new Transition(enemyController.IsDead, deathState));
        //    moveState.transitions.Add(new Transition(enemyController.IsDead, deathState));
        //    alignToState.transitions.Add(new Transition(enemyController.IsDead, deathState));
        //    attackState.transitions.Add(new Transition(enemyController.IsDead, deathState));

        //    idleState.onEnter += () => { animator.SetBool("Idle", true); };
        //    idleState.onExit += () => { animator.SetBool("Idle", false); };
        //    moveState.onEnter += () => { animator.SetBool("Chase", true); };
        //    moveState.onExit += () => { animator.SetBool("Chase", false); };
        //    alignToState.onEnter += () => { animator.SetBool("Aim", true); };
        //    alignToState.onExit += () => { animator.SetBool("Aim", false); };
        //    attackState.onEnter += () => { animator.SetBool("Attack", true); };
        //    attackState.onExit += () => { animator.SetBool("Attack", false); };
        //    deathState.onEnter += () => { animator.SetTrigger("Death"); };
        //    deathState.onExit += () => { };

        //    //Default state is idleState.
        //    currentState = idleState;
        //    currentState.Enter();
            
        //}

        //// Update is called once per frame
        //void Update()
        //{
        //    currentState.Step();
        //    if (currentState.NextState() != null)
        //    {
        //        //Cache the next state, because after currentState.Exit, calling
        //        //currentState.NextState again might return null because of change
        //        //of context.
        //        State nextState = currentState.NextState();
        //        currentState.Exit();
        //        currentState = nextState;
        //        currentState.Enter();
        //    }
        //    if (enemyController.IsDead())
        //    {
        //        Destroy(this.gameObject, 3f);
        //    }
        //}

       
    }
}


