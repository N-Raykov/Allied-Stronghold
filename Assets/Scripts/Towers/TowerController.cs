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
    [SerializeField] int damage = 10;
    [SerializeField] float range = 20f;
    [SerializeField] int cost = 10;

    bool attacking = false;

    void Start()
    {
        if(targetTransform == null)
        {
            targetTransform = GameObject.Find("StandardEnemy").transform;
        }

        attacking = true;
    }

    private void OnEnable()
    {
        EventBus<TowerPlaced>.OnEvent += OnPlaced;
    }

    private void OnDisable()
    {
        EventBus<TowerPlaced>.OnEvent -= OnPlaced;
    }

    void OnPlaced(TowerPlaced eventData)
    {
        attacker.SetTarget(targetTransform);
        attacker.SetTower(this.transform, this.gameObject.name);
        StartCoroutine(attackCoroutine());
        EventBus<TowerPlaced>.OnEvent -= OnPlaced;
        EventBus<MoneyChanged>.Publish(new MoneyChanged(-cost));
    }

    private IEnumerator attackCoroutine()
    {
        while (attacking)
        {
            yield return new WaitForSeconds(attackInterval);
            attacker.Attack();
        }
    }
}
