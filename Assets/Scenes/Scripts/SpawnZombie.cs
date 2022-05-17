using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    [SerializeField]
    private GameObject entityToSpawn;

    [SerializeField]
    private SpawnManagerPreset spawnManagerPreset;

    private int instanceNumber = 1;

    private void Start()
    {
        SpawnEntities();
    }
    
    private void SpawnEntities()
    {
        var currentSpawnIndexPoint = 0;
        for (int i = 0; i < spawnManagerPreset.NumberOfPrefabsToCreate; i++)
        {
            var currentEntity = Instantiate(entityToSpawn, spawnManagerPreset.SpawnPoints[currentSpawnIndexPoint], Quaternion.identity);
            currentEntity.name = spawnManagerPreset.PrefabName + instanceNumber;
            currentSpawnIndexPoint = (currentSpawnIndexPoint + 1) % spawnManagerPreset.SpawnPoints.Length;
            instanceNumber++;
        }
    }

}
