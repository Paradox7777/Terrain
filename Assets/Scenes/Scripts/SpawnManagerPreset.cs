using UnityEngine;
[CreateAssetMenu(fileName = "SpawnManagerPreset", menuName = "ScriptableObjects/SpawnManagerPreset ", order = 1)]

public class SpawnManagerPreset : ScriptableObject
{
    [SerializeField]
    private string prefabName;
    [SerializeField]
    private int numberOfPrefabsToCreate;
    [SerializeField]
    private Vector3[] spawnPoints;

    public string PrefabName => prefabName; 
    public int NumberOfPrefabsToCreate => numberOfPrefabsToCreate;
    public Vector3[] SpawnPoints => spawnPoints;
}
