using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;
    [SerializeField] private Button[] _levelButtons;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _sceneFader.FadeTo(0);
        }
    }
    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                _levelButtons[i].interactable = false;
            }

        }
    }
    public void SelectLevel(int level)
    {
        _sceneFader.FadeTo(level);
    }
}
