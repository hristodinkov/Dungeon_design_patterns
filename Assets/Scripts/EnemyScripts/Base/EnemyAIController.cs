using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    private FSM fsm;
    private Blackboard blackboard;

    [SerializeField] private Transform target;
    [SerializeField] private EnemyType enemyType;

    private void Start()
    {
        blackboard = GetComponent<Blackboard>();
        target = FindAnyObjectByType<PlayerController>().transform;

        blackboard.enemyTransform = transform;
        blackboard.agent = GetComponent<NavMeshAgent>();
        blackboard.enemyController = GetComponent<EnemyController>();
        blackboard.target = target;

        blackboard.agent.updateRotation = false;

        switch (enemyType)
        {
            case EnemyType.Skeleton:
                fsm = new SkeletonFSM(blackboard);
                break;

            case EnemyType.Mage:
                fsm = new MageFSM(blackboard);
                break;

            case EnemyType.Dragon:
                fsm = new DragonFSM(blackboard);
                break;
        }


        fsm.Enter();
    }

    private void Update()
    {
        float speed = blackboard.agent.velocity.magnitude;

        fsm.Step();
    }
}
