using System;
using UnityEngine;

public class AttackDetection : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool isPlayer;
    public bool isEnemy;

    public GameObject hitFx;

    private void Update()
    {
        DetectCollision();
    }

    void DetectCollision()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, collisionLayer);
        
        if(hits.Length > 0)
        {
            gameObject.SetActive(false);
        }
    }
}
