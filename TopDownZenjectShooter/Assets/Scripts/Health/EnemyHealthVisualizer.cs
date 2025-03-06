using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

public class EnemyHealthVisualizer : MonoBehaviour
{
    [SerializeField] private List<Config> _configs;
    [SerializeField] private Renderer _renderer;

    private SignalBus _signalBus;
    private EnemyHealth _enemyHealth;
    private Config _currentlyAppliedConfig;

    private void Awake()
    {
        _configs = _configs.OrderByDescending(c => c.PercentTreshold).ToList();
    }

    [Inject]
    public void Construct(SignalBus signalBus, EnemyHealth enemyHealth)
    {
        _signalBus = signalBus;
        _enemyHealth = enemyHealth;

        _signalBus.Subscribe<EnemyDamageTakenSignal>(OnEnemyDamageTaken);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<EnemyDamageTakenSignal>(OnEnemyDamageTaken);
    }

    private void OnEnemyDamageTaken(EnemyDamageTakenSignal signal)
    {
        if (signal.EnemyHealth != _enemyHealth)
            return;

        var healthPercentage = signal.EnemyHealth.GetHealthPercentage();
        var visualizationConfig = GetVisualizationConfig(healthPercentage);

        if(visualizationConfig != null)
        {
            ApplyVisualization(visualizationConfig);
        }
        else
        {
            Debug.LogError($"No config found for {healthPercentage}% enemy health visualization!");
        }
    }

    private void ApplyVisualization(Config config)
    {
        if (_currentlyAppliedConfig == config)
            return;

        _renderer.material = config.Material;
        _currentlyAppliedConfig = config;
    }

    private Config GetVisualizationConfig(float percentage)
    {
        var bestMatch = default(Config);

        foreach (var config in _configs)
        {
            if (percentage <= config.PercentTreshold)
            {
                bestMatch = config;
            }
            else
            {
                break; // found config with threshold greater than the percentage
            }
        }

        return bestMatch;
    }


    [System.Serializable]
    public class Config
    {
        [Range(0f, 100f)]
        public float PercentTreshold;
        public Material Material;
    }
}
