using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5;
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;
    private Vector3 _movement;
    private void Start()
    {
        _numSeedsLeft = _numSeeds;
        _numSeedsPlanted = 0;
        if (_plantCountUI != null)
            _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
        if (_playerTransform == null)
            _playerTransform = transform;
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        _movement = new Vector3(moveX, moveY, 0).normalized;

        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlantSeed();
        }
    }

    private void MovePlayer()
    {
        _playerTransform.position += _movement * _speed * Time.deltaTime;
    }

    public void PlantSeed()
    {
        if (_numSeedsLeft > 0)
        {
            if (_plantPrefab != null)
            {
                Vector3 plantPosition = _playerTransform.position;
                plantPosition.z = _playerTransform.position.z - 0.1f;
                Instantiate(_plantPrefab, _playerTransform.position, Quaternion.identity);
                _numSeedsLeft--;
                _numSeedsPlanted++;
                if (_plantCountUI != null)
                    _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
            }
            else
            {
                Debug.LogWarning("Plant prefab is not assigned!");
            }
        }
        else
        {
            Debug.Log("No seeds left!");
        }
    }
}