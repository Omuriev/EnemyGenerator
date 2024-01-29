using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Mummy _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _repeatRate;

    private void Start()
    {
        InvokeRepeating(nameof(CreateMummy), 0.0f, _repeatRate);
    }

    private void Update()
    {
        if (_target == null)
        {
            CancelInvoke(nameof(CreateMummy));
        }
    }

    private void CreateMummy()
    {
        Mummy mummy = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
        mummy.SetTarget(_target);
    }
}
