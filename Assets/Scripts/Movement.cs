using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _isMove = true;

    private void Update()
    {
        if (_isMove == true)
            Move();
    }

    public void SetMovingStatus(bool isMove)
    {
        _isMove = isMove;
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}
