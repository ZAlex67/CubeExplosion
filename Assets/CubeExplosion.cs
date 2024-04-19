using System.Collections.Generic;
using UnityEngine;

public class CubeExplosion : MonoBehaviour
{
    private float _forceRatio = 2f;

    public void Explode(float explosionForce, float explosionRadius)
    {
        foreach (Rigidbody explodableObject in GetExplodableObject(explosionRadius))
        {
            float distance = Vector3.Distance(transform.position, explodableObject.transform.position);

            Debug.Log("Distance: " + distance + "; Radius: " + explosionRadius);

            if (distance < explosionRadius)
            {
                explodableObject.AddExplosionForce(explosionForce / _forceRatio, transform.position, explosionRadius);
            }
            else
            {
                explodableObject.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }

    private List<Rigidbody> GetExplodableObject(float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, explosionRadius);

        List<Rigidbody> barrels = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                barrels.Add(hit.attachedRigidbody);
            }
        }

        return barrels;
    }
}