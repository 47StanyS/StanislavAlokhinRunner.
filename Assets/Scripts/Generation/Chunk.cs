using UnityEngine;

public class Chunk : MonoBehaviour
{
    private Spawner _spawner;
    private bool _spawnNextChunk = false;
    private void Awake()
    {
        _spawner =transform.parent.GetComponent<Spawner>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && _spawnNextChunk == false)
        {
            _spawner.ChunkSpawn(transform.position + Vector3.forward * 100);
            _spawnNextChunk = true;
        }
    }
}
