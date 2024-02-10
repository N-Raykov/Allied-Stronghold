using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAttack : AbstractAttacker
{
    //Shoots one projectile
    public override void Attack()
    {
        Vector2 projectileVelocity = (targetTransform.position - transform.position).normalized * projectileSpeed;
        Projectile projectileController = Instantiate<Projectile>(projectilePrefab);
        projectileController.transform.position = transform.position;
        projectileController.SetVelocity(projectileVelocity);



        Vector2 look = transform.InverseTransformPoint(targetTransform.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        projectileController.transform.Rotate(0, 0, angle - 90f);
    }
}
