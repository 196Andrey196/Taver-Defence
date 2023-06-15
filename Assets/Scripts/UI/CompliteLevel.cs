using UnityEngine;

public class CompliteLevel : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;
   
    private int _nextLevel = 2;
    private int _levelUnlock = 2;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", _levelUnlock);
        _sceneFader.FadeTo(_nextLevel + 1);
    }
    public void Menu()
    {
        _sceneFader.FadeTo(0);
    }
}
