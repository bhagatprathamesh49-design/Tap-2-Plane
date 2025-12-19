using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _minX = -15f;
    
    void Update()
    {
        transform.position += Vector3.left * _moveSpeed * Time.deltaTime;

        if(transform.position.x <= _minX)
        {
            Destroy(gameObject);
        }   
    }
}
