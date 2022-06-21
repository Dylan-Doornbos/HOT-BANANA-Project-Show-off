using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] private XRInteractionManager _interactionManager;
    [SerializeField] private Camera _camera;
    [SerializeField] private CanvasGroup _loadingScreen;
    [SerializeField] private float _fadeDuration;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        StartCoroutine(FadeOut());
    }

    public IEnumerator Fade(float pStart, float pEnd, float pDuration)
    {
        _loadingScreen.alpha = pStart;
        if (pDuration < 0) pDuration = _fadeDuration;
        
        DOTween.To(() => _loadingScreen.alpha, x => _loadingScreen.alpha = x, pEnd, pDuration);
        yield return new WaitForSeconds(pDuration);
    }

    public IEnumerator FadeIn(float pDuration = -1)
    {
        yield return StartCoroutine(Fade(0, 1, pDuration));
    }

    public IEnumerator FadeOut(float pDuration = -1)
    {
        yield return StartCoroutine(Fade(1, 0, pDuration));
    }

    private void OnDestroy()
    {
        if (instance == this) instance = null;
    }
}