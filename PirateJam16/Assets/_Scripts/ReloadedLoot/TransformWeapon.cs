using UnityEngine;

public class TransformWeapon : TransformItem
{
    [Header("Transform Weapon")]
    public float  fireDelay = 0.5f;
    private float nextTimeCanFire = 0f;
    public Projectile projectilePrefab;
    public Transform projectileSpawn;
    private Transform cameraTransform => PlayerManager.instance.playerCamera.m_Camera.transform;

    public override void UseItem()
    {
        if (isEquipped && Time.time > nextTimeCanFire)
            Fire();
    }

    public void Fire()
    {
        // Do animations and stuff
        base.UseItem();

        Projectile spawnedBullet = Instantiate<Projectile>(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);

        // Add boolean for using camera or weapon transform
        // Get direction to send bullet
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(50f);

        Vector3 shootDirection = targetPoint - projectileSpawn.position;

        // for spread add offset here

        spawnedBullet.Shoot(shootDirection);

        // play sfx and animation

        nextTimeCanFire = Time.time + fireDelay;
    }
}
