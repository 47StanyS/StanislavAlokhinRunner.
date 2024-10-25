using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] _chunks;

    [Range(0,100)]public int _clearChunkChance;

    private void Start()
    {
        Vector3 _spawnPosition = transform.position;

        for (int i = 0; i < 10; i++)
        {
            GameObject SpawnChunk;

            if (_clearChunkChance > Random.Range(0,100)) 
            {
                int randomChank = Random.Range(0, _chunks.Length);
                SpawnChunk = _chunks[randomChank];

            }
            else
            {
                SpawnChunk = _chunks[0];
            }
            if (i == 0) 
            {
                SpawnChunk = _chunks[0];
            }
            Instantiate(SpawnChunk, _spawnPosition, Quaternion.identity, transform);
            _spawnPosition.z += 10;
        }
    }

    public void ChunkSpawn(Vector3 position)
    {

        Instantiate(_chunks[Random.Range(0, _chunks.Length)], position, Quaternion.identity, transform);
    }
}
