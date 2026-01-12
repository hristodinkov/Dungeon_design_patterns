using UnityEngine;
using UnityEngine.AI;

public class Blackboard : MonoBehaviour
{
    [Header("References")]
    public Transform enemyTransform;
    public Transform target;
    public NavMeshAgent agent;
    public Animator animator;
    public Collider attackCollider;
    public EnemyController enemyController;

    public GameObject projectilePrefab;
    public Transform shootPoint;

    [Header("AI Settings")]
    public float chaseRange = 4f;
    public float attackRange = 1.5f;
    public float rotateSpeed = 120f;
    public float attackCooldown = 0.8f;
    public float projectileSpeed = 10f;
    public float stoppingDistance = 3f;

    [Header("Runtime")]
    public float lastAttackTime;
    public Vector3 targetPosition;

    [Header("Dragon Settings")] 
    public float phase2Threshold = 0.5f; 

    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
        animator = GetComponent<Animator>();
    }
}
