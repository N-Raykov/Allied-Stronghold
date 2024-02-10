using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector2 velocity;

    public void SetVelocity(Vector2 pVelocity)
    {
        velocity = pVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * velocity, Space.World);
    }
}
