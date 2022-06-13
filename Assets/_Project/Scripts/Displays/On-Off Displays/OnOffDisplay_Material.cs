using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class OnOffDisplay_Material : OnOffDisplay
{
    private MeshRenderer _renderer;
    [SerializeField] private Material _onMaterial;
    [SerializeField] private Material _offMaterial;

    private void findRenderer()
    {
        if(_renderer != null) return;

        _renderer = GetComponent<MeshRenderer>();
    }

    protected override void showState(bool pIsActive)
    {
        findRenderer();
        _renderer.material = pIsActive ? _onMaterial : _offMaterial;
    }
}