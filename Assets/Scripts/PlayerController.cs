using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _rotationMultiplier = 2f;
    [SerializeField] private GameObject _menu;

    private Rigidbody2D _rigidBody;
    private int _score = 0;

    public int Score
    {
        get
        {
            return _score;
        }
    }

    public bool isAlive
    {
        get
        {
            return gameObject.activeSelf;
        }
    }
   
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);   
    }

    
    void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            _rigidBody.linearVelocity = Vector2.up * _jumpForce;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, _rigidBody.linearVelocity.y * _rotationMultiplier);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        _menu.SetActive(true);
        _score = 0;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _score += 1;
    }
}
