using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    //Like in the composition example this script doesn't have its own attacking method
    //and delegates it to a dedicated attacker

    [SerializeField] AbstractAttacker attacker;

    [SerializeField] Transform targetTransform;

    [SerializeField] float attackInterval = 1f;

    bool attacking = false;

    void Start()
    {
        attacking = true;
        attacker.SetTarget(targetTransform);
        attacker.SetTower(this.transform);
        StartCoroutine(attackCoroutine());
    }

    private IEnumerator attackCoroutine()
    {
        while (attacking)
        {
            yield return new WaitForSeconds(attackInterval);
            attacker.Attack();
            Debug.Log(transform.position);
            Debug.Log(attacker.transform.position);
        }
    }
}
