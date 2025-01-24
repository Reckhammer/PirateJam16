using UnityEngine;

public class TransformWeapon : TransformItem
{
    [Header("Transform Weapon")]
    public float  fireDelay = 0.5f;
    private float nextTimeCanFire = 0f;
    public Projectile projectilePrefab;
    public Transform projectileSpawn;

    public override void UseItem()
    {
        if (isEquipped && Time.time > nextTimeCanFire)
            Fire();
    }

    public void Fire()
    {
        Projectile spawnedBullet = Instantiate<Projectile>(projectilePrefab);

        // Get direction to send bullet
        Ray ray = PlayerManager.instance.playerCamera.m_Camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(50f);

        Vector3 shootDirection = targetPoint - projectileSpawn.position;

        // for spread add offset here

        spawnedBullet.Shoot(shootDirection);

        // play sfx

        nextTimeCanFire = Time.time + fireDelay;
    }
}
