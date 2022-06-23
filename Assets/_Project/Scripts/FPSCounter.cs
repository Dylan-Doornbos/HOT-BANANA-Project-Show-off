using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private IEnumerator writeFPS()
    {
        while (true)
        {
            _text.text = getFPS();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private string getFPS()
    {
        float fps = 1f / Time.deltaTime;
        
        return string.Format("{0:00}", fps);
    }

    private void OnEnable()
    {
        StartCoroutine(writeFPS());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}