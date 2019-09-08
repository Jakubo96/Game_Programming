using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;

    private Rigidbody myBody;
    public float speed = 1.8f;

    private Transform playerTarget;

    public float attackDistance = 1.3f;
    public float chasePlayerAfterAttack = 1f;

    private float currentAttackTime;
    public float defaultAttackTime = 2f;

    private bool followPlayer;
    private bool attackPlayer;

    private void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        myBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    void Start()
    {
        followPlayer = true;
        currentAttackTime = defaultAttackTime;
    }

    void Update()
    {
        AttackTarget();
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (!followPlayer)
        {
            return;
        }

        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
        {
            transform.LookAt(playerTarget);
            myBody.velocity = transform.forward * speed;

            if (myBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            myBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;
        }
    }

    void AttackTarget()
    {
        if (!attackPlayer)
        {
            return;
        }

        currentAttackTime += Time.deltaTime;

        if (currentAttackTime > defaultAttackTime)
        {
            enemyAnim.EnemyAttack(Random.Range(EnemyAttacks.MIN_ATTACK, EnemyAttacks.MAX_ATTACK));

            currentAttackTime = 0f;
        }

        if (Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}