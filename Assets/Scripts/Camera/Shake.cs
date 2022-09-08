using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float duration = 1f;
    public float magnitude = 1f;
    public IEnumerator Shaking()
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0f;
        while (elapsed<duration)
        {
            float x = Random.Range(-1,1)*magnitude;
            float y = Random.Range(-1,1)*magnitude;
            transform.localPosition = new Vector3(x,y,originalPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPosition;
    }
}
