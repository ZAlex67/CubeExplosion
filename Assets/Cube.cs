using UnityEngine;

[RequireComponent(typeof(CubeExplosion))]
public class Cube : MonoBehaviour
{
    private CubeExplosion _cubeExplosion;

    private int _sacaleRatio = 2;
    private Color[] _color = new Color[] { Color.green, Color.black, Color.blue, Color.red };
    private int _ratio = 200;
    private int _ratioChange = 2;

    private void Start()
    {
        _cubeExplosion = GetComponent<CubeExplosion>();
    }

    private void OnMouseUpAsButton()
    {
        ExplodeAction();
    }

    private void ExplodeAction()
    {
        int currentRatio = GetRandomRatio();
        _ratio /= _ratioChange;

        _cubeExplosion.Explode();
        Destroy(gameObject);
        if (currentRatio <= _ratio)
        {
            CreateManually();
            Debug.Log(_ratio);
            Debug.Log(currentRatio);
        }
    }

    private void CreateManually()
    {
        int cubeNumber = GetRandomCubeNumber();

        for (int i = 0; i < cubeNumber; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.GetComponent<Renderer>().material.color = _color[Random.Range(0, _color.Length)];
            cube.AddComponent<BoxCollider>();
            cube.AddComponent<Rigidbody>();
            cube.AddComponent<Cube>();
            cube.AddComponent<CubeExplosion>();
            cube.transform.position = transform.position;
            cube.transform.localScale = transform.localScale / _sacaleRatio;
        }
    }

    private int GetRandomRatio()
    {
        int minRatio = 0;
        int maxRatio = 100;

        return Random.Range(minRatio, maxRatio);
    }

    private int GetRandomCubeNumber()
    {
        int minRatio = 2;
        int maxRatio = 5;

        return Random.Range(minRatio, maxRatio);
    }
}