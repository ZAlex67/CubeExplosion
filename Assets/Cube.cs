using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 20f;
    [SerializeField] private float _explosionForce = 700f;

    private int _sacaleRatio = 2;
    private Color[] _color = new Color[] { Color.green, Color.black, Color.blue, Color.red };
    private int _ratio = 200;
    private int _currentRatio = 100;
    private int _ratioChange = 2;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentRatio = GetRandomRatio();
            _ratio = _ratio / _ratioChange;
        }
    }

    private void OnMouseUpAsButton()
    {
        Explode();
        Destroy(gameObject);
        if (_currentRatio <= _ratio)
        {
            CreateManually();
            CreateManually();
            Debug.Log(_ratio);
            Debug.Log(_currentRatio);
        }
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObject())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> barrels = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                barrels.Add(hit.attachedRigidbody);

        return barrels;
    }

    private void CreateManually()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Renderer>().material.color = _color[Random.Range(0, _color.Length)];
        cube.AddComponent<BoxCollider>();
        cube.AddComponent<Rigidbody>();
        cube.AddComponent<Cube>();
        cube.transform.position = transform.position;
        cube.transform.localScale = transform.localScale / _sacaleRatio;
    }

    private int GetRandomRatio()
    {
        int minRatio = 0;
        int maxRatio = 100;

        return Random.Range(minRatio, maxRatio);
    }
}