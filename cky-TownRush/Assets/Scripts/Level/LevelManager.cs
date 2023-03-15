using cky.Buildings;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] LevelSettings[] levelSettings;
    public LevelSettings settings;

    private void Awake()
    {
        Instance = this;

        settings = levelSettings[0];
    }

    private void Start()
    {
        new BuildingSpawner(settings);
    }
}