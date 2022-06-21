using System.Collections.Generic;
using UnityEngine;

public class CullChainManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer _culledObject;
    [SerializeField] private List<GameObject> _objectsToCull;

    private CullPasser _passer;

    private void Awake()
    {
        if(_culledObject == null) return;

        _passer = _culledObject.gameObject.AddComponent<CullPasser>();
        _passer.onInvisible += disable;
        _passer.onVisible += enable;

        if (_passer.GetComponent<MeshRenderer>().isVisible)
        {
            enable();
        }
        else
        {
            disable();
        }
    }

    private void disable()
    {
        setObjectsActive(false);
    }

    private void enable()
    {
        setObjectsActive(true);
    }

    private void setObjectsActive(bool pAreActive)
    {
        _objectsToCull.ForEach(x => x.SetActive(pAreActive));
    }
}