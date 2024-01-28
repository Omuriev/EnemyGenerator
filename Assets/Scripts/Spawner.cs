using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Mummy _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _repeatRate;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxCapacity;

    private ObjectPool<Mummy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Mummy>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxCapacity
            );
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetMummy), 0.0f, _repeatRate);
    }

    private void GetMummy()
    {
        _pool.Get();
    }

    private void ActionOnGet(Mummy obj)
    {
        obj.gameObject.SetActive(true);
        obj.transform.position = GetRandomSpawnPoint();
        Vector3 direction = (_target.position - obj.transform.position).normalized;
        obj.transform.forward = direction;
    }

    private Vector3 GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out Mummy mummy))
        {
            _pool.Release(mummy);
        }
    }
}
