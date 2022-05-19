using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneTransitionInteractable : XRBaseInteractable
{
    [Min(0)][SerializeField] int _sceneID;
    SceneTransition _sceneTransition = new SceneTransition();

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        _sceneTransition.ChangeScene(_sceneID);
    }
}
