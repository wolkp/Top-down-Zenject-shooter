using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class CharacterStatesInstaller<TInitializer, TRegistry> : ScriptableObjectInstaller
    where TInitializer: CharacterStatesInitializer
    where TRegistry : CharacterStatesRegistry
{
    [SerializeField] private Settings _settings;

    public override void InstallBindings()
    {
        Container.Bind<Settings>().FromInstance(_settings).AsSingle();

        var allStates = new List<CharacterState>();
        foreach (var stateInstaller in _settings.StateInstallers)
        { 
            Container.Inject(stateInstaller.CharacterState);
            allStates.Add(stateInstaller.CharacterState);
        }

        Container.Bind<IEnumerable<CharacterState>>().FromInstance(allStates).AsSingle();

        Container.BindInterfacesAndSelfTo<TInitializer>().AsSingle();
    }

    [Serializable]
    public class Settings
    {
        public List<CharacterStateInstaller> StateInstallers;
    }
} 