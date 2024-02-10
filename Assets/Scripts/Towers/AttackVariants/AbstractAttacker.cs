using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAttacker : MonoBehaviour
{
    protected Transform targetTransform;

    [SerializeField] protected float projectileSpeed = 2f;

    [SerializeField] protected Projectile projectilePrefab;

    public void SetTarget(Transform pTargetTransform)
    {
        targetTransform = pTargetTransform;
    }

    public void SetTower(Transform pTowerTransform)
    {
        transform.position = pTowerTransform.position;
    }

    public abstract void Attack();
}
