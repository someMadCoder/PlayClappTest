using System.Collections;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer _renderer;

    private int _shaderProperty;

    private float _timeToLive;
    private float _leftTimeToLive;

    public void Init(float timeToLive)
    {
        _timeToLive = timeToLive;
        _leftTimeToLive = _timeToLive;
        _shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();
        StartCoroutine(UpdateDissolveValue());
    }

    private IEnumerator UpdateDissolveValue()
    {
        while (_leftTimeToLive > 0)
        {
            _leftTimeToLive -= Time.unscaledDeltaTime;
            float dissolveValue = _leftTimeToLive / _timeToLive;
            _renderer.material.SetFloat(_shaderProperty, 1f - Mathf.Clamp01(dissolveValue));
            yield return null;
        }
    }
}
