using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private AnimationCurve _velocityCurve;

    private Rigidbody2D rb;
    private Vector2 _direction;
    private bool _rightDirection = false;
    private float _curveTime, _totalTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _totalTime = _velocityCurve.keys[_velocityCurve.length - 1].time;
    }
    void FixedUpdate()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");

        rb.velocity = _direction * speed * _velocityCurve.Evaluate(_curveTime);

        if(_curveTime >= _totalTime)
        {
            _curveTime = 0;
        }

        if (_direction.x > 0 && _rightDirection == false)
        {
            Flip();
        }
        if (_direction.x < 0 && _rightDirection == true)
        {
            Flip();
        }
    }
    private void Update()
    {
        _curveTime += Time.deltaTime;
    }

    #region Flip:)
    private void Flip()
    {
        _rightDirection = !_rightDirection;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    #endregion
}
