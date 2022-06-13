using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private XROrigin _playerPrefab;

    private XROrigin _player;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }

    private void Awake()
    {
        _player = FindObjectOfType<XROrigin>();

        if (_player == null)
        {
            _player = Instantiate(_playerPrefab);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Start()
    {
        if(_player == null) return;

        Transform player = _player.transform;
        var playerTransform = transform;

        player.position = playerTransform.position;
        player.rotation = playerTransform.rotation;
    }
}