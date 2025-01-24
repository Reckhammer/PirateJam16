using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    public float damage = 5f;
    public float velocity = 30f;
    public float timeToLive = 2f;

    private Rigidbody m_rigidbody;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 direction)
    {
        transform.forward = direction.normalized;
        m_rigidbody.AddForce(direction * velocity, ForceMode.Impulse);

        StartCoroutine(DestroyAfterTTL());
    }

    private IEnumerator DestroyAfterTTL()
    {
        yield return new WaitForSeconds(timeToLive);

        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health collisionHealth))
            collisionHealth.DamageHealth((int)damage);

        StopAllCoroutines();
        Destroy(this.gameObject);
    }
}
