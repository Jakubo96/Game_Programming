using UnityEngine;

public class AttackDetection : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool isPlayer;
    public bool isEnemy;

    public GameObject hitFxPrefab;

    private void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hits.Length <= 0) return;
        
        if (isPlayer)
        {
            var hitFxPosition = hits[0].transform.position;
            hitFxPosition.y += 1.3f;

            if (hits[0].transform.forward.x > 0)
            {
                hitFxPosition.x += 0.3f;
            }
            else if (hits[0].transform.forward.x < 0)
            {
                hitFxPosition.x -= 0.3f;
            }

            Instantiate(hitFxPrefab, hitFxPosition, Quaternion.identity);

            if (gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG__TAG))
            {
//                hits[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
            }
            else
            {
//                hits[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
            }
        }

        gameObject.SetActive(false);
    }
}