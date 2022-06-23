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
    [SerializeField] private MeshRenderer _capsule;
    [SerializeField] private float _fadeDuration;

    private Material _material;
    private static readonly int ALPHA = Shader.PropertyToID("Alpha");

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _loadingScreen.gameObject.SetActive(false);
        _material = _capsule.material;
        
        instance = this;
        StartCoroutine(FadeOut());
    }

    public IEnumerator Fade(float pStart, float pEnd, float pDuration)
    {
        _material.SetFloat(ALPHA, pStart);
        if (pDuration < 0) pDuration = _fadeDuration;

        DOTween.To(() => _material.GetFloat(ALPHA), x => _material.SetFloat(ALPHA, x), pEnd, pDuration);
        
        /*
        _loadingScreen.alpha = pStart;
        if (pDuration < 0) pDuration = _fadeDuration;
        
        DOTween.To(() => _loadingScreen.alpha, x => _loadingScreen.alpha = x, pEnd, pDuration);*/
        yield return new WaitForSeconds(pDuration);
    }

    public IEnumerator FadeIn(float pDuration = -1)
    {
        yield return StartCoroutine(Fade(0, 1, pDuration));
    }

    public void SetLoadingTextVisibility(bool pIsVisible)
    {
        _loadingScreen.gameObject.SetActive(pIsVisible);
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