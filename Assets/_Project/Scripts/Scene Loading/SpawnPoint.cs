using Unity.XR.CoreUtils;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private XROrigin _playerPrefab;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);
        Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    }

    private void Start()
    {
        if(Player.instance == null) Instantiate(_playerPrefab);;

        Transform player = Player.instance.transform;
        var playerTransform = transform;

        player.position = playerTransform.position;
        player.rotation = playerTransform.rotation;
    }
}