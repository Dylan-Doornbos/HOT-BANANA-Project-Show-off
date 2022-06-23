using System.Collections.Generic;
using UnityEngine;

public class MaterialRandomizer : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _renderersToRandomize;
    [SerializeField] private Material[] _materials;

    private void Awake()
    {
        int matIndex = Random.Range(0, _materials.Length);
        Material material = _materials[matIndex];

        _renderersToRandomize.ForEach(x => x.material = material);
    }
}
