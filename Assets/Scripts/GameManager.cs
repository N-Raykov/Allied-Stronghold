using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int money;

    private void OnEnable()
    {
        EventBus<DamageTaken>.OnEvent += DamageTaken;
        EventBus<MoneyChanged>.OnEvent += MoneyChanged;
    }

    private void OnDisable()
    {
        EventBus<DamageTaken>.OnEvent -= DamageTaken;
        EventBus<MoneyChanged>.OnEvent -= MoneyChanged;
    }

    void DamageTaken(DamageTaken eventData)
    {
        health -= 1;
        
        if (health <= 0)
        {
            Debug.Log("game over");
        }
    }

    void MoneyChanged(MoneyChanged eventData)
    {
        money += eventData.Amount;
    }
}
