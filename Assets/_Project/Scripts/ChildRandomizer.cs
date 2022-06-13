using UnityEngine;
using Random = UnityEngine.Random;

public class ChildRandomizer : MonoBehaviour
{
    [SerializeField] GameObject[] _prefabs;

    private void OnEnable()
    {
        randomizePrefab();
    }

    private void randomizePrefab()
    {
        TransformHelper.DeleteChildren(transform);
        
        int rndIndex = Random.Range(0, _prefabs.Length);
        Instantiate(_prefabs[rndIndex], transform.position, Quaternion.identity, transform);
    }
}