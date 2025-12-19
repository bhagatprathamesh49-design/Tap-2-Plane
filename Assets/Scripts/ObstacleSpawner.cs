using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _obstacle;
    [SerializeField] private float _yOffsetMin = 1f, _yOffsetMax = 3f;
    [SerializeField] private PlayerController _player;
    
    private float _spawnFrequency = 3f;

    private float _timeTillNextSpawn = 0f;
    
    void Update()
    {
        if(_timeTillNextSpawn <= 0f && _player.isAlive)
        {
            Vector3 newPosition = new Vector3(transform.position.x, Random.Range(_yOffsetMin, _yOffsetMax));
            Instantiate(_obstacle, newPosition, transform.rotation);
            _timeTillNextSpawn = _spawnFrequency;
        }
        else
        {
            _timeTillNextSpawn -= Time.deltaTime;
        }
    }
}
