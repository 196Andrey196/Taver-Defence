using UnityEngine;
using TMPro;

public class LivesUi : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _playerLiveText;
    private void Update()
    {

        _playerLiveText.text = PlayerStats.curentLive + " LIVES";

    }
}
