using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool shakeControl;
    private int shakeEffectControl = 0;
    public IEnumerator CameraShakes(float duration, float magnitude)
    {
        
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-2f, 2f) * magnitude;
            float y = Random.Range(-2f, 2f) * magnitude;

            transform.localPosition = new Vector3(x,y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;

        }

        transform.localPosition = originalPos;

    }
    public void CameraShakesCall()
    {
        //if(shakeControl == false)
        {
            StartCoroutine(CameraShakes(0.20f, 0.6f));
        //    shakeControl = true;
        }
    }
}
