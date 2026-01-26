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
        FSMSetUp();
        fsm.Enter();
    }

    private void FSMSetUp()
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
    }

    private void Update()
    {
        fsm.Step();
    }
}
