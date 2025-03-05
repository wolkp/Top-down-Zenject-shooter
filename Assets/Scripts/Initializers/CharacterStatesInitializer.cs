using System.Collections.Generic;
using Zenject;

public class CharacterStatesInitializer : IInitializable
{
    [Inject] private readonly CharacterStatesRegistry _statesRegistry;
    [Inject] private readonly IEnumerable<CharacterState> _states;

    public void Initialize()
    {
        foreach (var state in _states)
        {
            _statesRegistry.AddItem(state);
        }
    }
}