using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Cube _cube;
    [SerializeField] private ParticleSystem _spawnEffect;
    private float _cooldownTime = 1;
    private float _cubeSpeed = 1;
    private float _cubeLiveDistance = 1;
    private float _nextTimeToSpawn;

    private Quaternion RandomRotation => Quaternion.LookRotation(Random.onUnitSphere);

    public void SetCooldownTime(string cooldownTime)
    {
        float.TryParse(cooldownTime, out float time);
        SetCooldownTime(time);
    }

    public void SetCubeLiveDistance(string distance)
    {
        float.TryParse(distance, out float cubeDistance);
        SetCubeDistance(cubeDistance);
    }

    public void SetCubeSpeed(string speed)
    {
        float.TryParse(speed, out float cubeSpeed);
        SetCubeSpeed(cubeSpeed);
    }

    private void SetCooldownTime(float cooldownTime)
    {
        _cooldownTime = cooldownTime;
    }

    private void SetCubeSpeed(float speed)
    {
        _cubeSpeed = speed;
    }

    private void SetCubeDistance(float distance)
    {
        _cubeLiveDistance = distance;
    }

    private void Update()
    {
        if (Time.time > _nextTimeToSpawn)
        {
            SpawnCube(_cubeSpeed, _cubeLiveDistance);
            _nextTimeToSpawn = Time.time + _cooldownTime;
        }
    }

    private void SpawnCube(float cubeSpeed, float cubeLiveDistance)
    {
        Cube cube = Instantiate(_cube, transform.position, RandomRotation);
        cube.Init(cubeSpeed, cubeLiveDistance);
        PlaySpawnEffect();
    }

    private void PlaySpawnEffect()
    {
        _spawnEffect.Play();
    }
}
