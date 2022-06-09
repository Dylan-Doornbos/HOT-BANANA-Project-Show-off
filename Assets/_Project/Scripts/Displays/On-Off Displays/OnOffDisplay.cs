using UnityEngine;

public abstract class OnOffDisplay : MonoBehaviour
{
    public bool state { get; private set; }

    public void SetState(bool pIsActive)
    {
        state = pIsActive;
        showState(pIsActive);
    }

    protected abstract void showState(bool pIsActive);
}
