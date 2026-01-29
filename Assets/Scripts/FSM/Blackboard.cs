using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using NaughtyAttributes;

public class Blackboard : MonoBehaviour
{
    [Header("Enemy Type")]
    public EnemyType enemyType;
    public bool IsMelee => enemyType == EnemyType.Skeleton || enemyType == EnemyType.Dragon;
    public bool IsRanged => enemyType == EnemyType.Mage || enemyType == EnemyType.Dragon;
    public bool IsDragon => enemyType == EnemyType.Dragon;

    [Header("References")]
    public Transform enemyTransform;
    public Transform target;
    public NavMeshAgent agent;
    public Animator animator;

    [ShowIf("IsMelee")]
    public Collider attackCollider;

    public EnemyController enemyController;

    [ShowIf("IsRanged")]
    public GameObject projectilePrefab;
    [ShowIf("IsRanged")]
    public Transform shootPoint; 

    [Header("AI Settings")]
    public float chaseRange;
    public float attackRange;
    public float rotateSpeed;
    public float attackCooldown;
    [ShowIf("IsRanged")]
    public float projectileSpeed;
    [ShowIf("IsRanged")]
    public float optimalRange = 4f;
    [ShowIf("IsRanged")]
    public float minRange = 3f;
    [ShowIf("IsRanged")]
    public float maxRange = 5f;

    [Header("Dragon Settings"),ShowIf("IsDragon")]
    public float phase2Threshold = 0.5f;
    [ShowIf("IsDragon")]
    public bool phase2;
    [ShowIf("IsDragon")]
    public Collider dragonCollider;

    protected void Start()
    {
        enemyController = GetComponent<EnemyController>();
        animator = GetComponent<Animator>();
    }
} 
