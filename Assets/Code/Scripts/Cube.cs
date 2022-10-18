using UnityEngine;

[RequireComponent(typeof(DissolveEffect))]
public class Cube : MonoBehaviour
{
    private float _speed;

    public void Init(float cubeSpeed, float cubeLiveDistance)
    {
        _speed = cubeSpeed;
        float timeToLive = cubeLiveDistance / cubeSpeed;
        Destroy(gameObject, timeToLive);
        GetComponent<DissolveEffect>().Init(timeToLive);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}