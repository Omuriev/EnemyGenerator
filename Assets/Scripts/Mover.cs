using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _isMove = true;
    private Vector3 _targetPosition;

    private void Update()
    {
        if (_isMove == true)
        {
            Move();
            SetDirection();
        } 
    }

    public void SetMovingStatus(bool isMove)
    {
        _isMove = isMove;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }

    public void SetDirection()
    {
        Vector3 direction = (_targetPosition - transform.position).normalized;
        transform.forward = direction;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
}
