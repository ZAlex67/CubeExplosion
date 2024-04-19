using UnityEngine;

[RequireComponent(typeof(CubeExplosion))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private CubeExplosion _cubeExplosion;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private int _sacaleRatio = 2;
    private Color[] _color = new Color[] { Color.green, Color.black, Color.blue, Color.red };
    private int _ratio = 200;
    private int _ratioChange = 2;

    private void OnMouseUpAsButton()
    {
        ExplodeAction();
    }

    private void ExplodeAction()
    {
        int currentRatio = GetRandomRatio();

        if (currentRatio <= _ratio)
        {
            CreateManually();
        }

        _cubeExplosion.Explode(_explosionForce, _explosionRadius);

        Destroy(gameObject);
    }

    private void CreateManually()
    {
        int cubeNumber = GetRandomCubeNumber();

        _ratio /= _ratioChange;

        for (int i = 0; i < cubeNumber; i++)
        {
            Cube cube = Instantiate(this);
            cube.GetComponent<Renderer>().material.color = _color[Random.Range(0, _color.Length)];
            cube.transform.localScale = transform.localScale / _sacaleRatio;
            cube._ratio = _ratio;
            _explosionForce += 100f;
            _explosionRadius += 1f;
            Debug.Log(_explosionForce);
            Debug.Log(_explosionRadius);
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