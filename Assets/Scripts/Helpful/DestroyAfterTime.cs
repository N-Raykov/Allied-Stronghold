using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float timer = 2f;

    private void Start()
    {
        Destroy(this.gameObject, timer);
    }
}
