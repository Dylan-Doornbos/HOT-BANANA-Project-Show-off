using UnityEngine;

public class OnOffDisplay_Material : OnOffDisplay
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Material _onMaterial;
    [SerializeField] private Material _offMaterial;

    private void Awake()
    {
        if (_renderer == null)
        {
            _renderer = GetComponent<MeshRenderer>();
        }

        if (_renderer == null || _onMaterial == null || _offMaterial == null)
        {
            DebugUtil.Log($"Missing references for '{GetType()}' on '{gameObject.name}'.", LogType.ERROR);
        }
    }

    protected override void showState(bool pIsActive)
    {
        _renderer.material = pIsActive ? _onMaterial : _offMaterial;
    }
}