using UnityEngine;

[RequireComponent(typeof(CubeExplosion))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private CubeExplosion _cubeExplosion;

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

        _cubeExplosion.Explode();
        Destroy(gameObject);

        if (currentRatio <= _ratio)
        {
            CreateManually();
        }
    }

    private void CreateManually()
    {
        int cubeNumber = GetRandomCubeNumber();
        _ratio /= _ratioChange;

        for (int i = 0; i < cubeNumber; i++)
        {
            Cube cube = Instantiate(_cube, transform.position, Quaternion.identity);
            cube.GetComponent<Renderer>().material.color = _color[Random.Range(0, _color.Length)];
            cube.transform.localScale = transform.localScale / _sacaleRatio;
            cube._ratio = _ratio;
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