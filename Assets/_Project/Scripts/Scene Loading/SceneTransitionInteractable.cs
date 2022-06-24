using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneTransitionInteractable : XRBaseInteractable
{
    [Min(0)][SerializeField] IntSO _scene;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        GameManager.instance.LoadScene(_scene.value);
    }
}
