using Levels;
using UnityEngine;
using UnityEngine.Playables;

public class LevelSimplePlatforms : Level
{
    [SerializeField] private GameObject levelPlatform;
    [SerializeField] private PlayableDirector timeline;

    internal override void OnEnter()
    {
        levelPlatform.SetActive(true);
        timeline.Play();
    }

    internal override void OnExit()
    {
        levelPlatform.SetActive(false);
        timeline.Stop();
    }
}
