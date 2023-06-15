using TMPro;
using System.Collections;
using UnityEngine;

public class RoundSurvived : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _roundsSurvive;
    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }
    private IEnumerator AnimateText()
    {
        _roundsSurvive.text = "0";
        int round = 0;
        yield return new WaitForSeconds(0.7f);
        while (round < PlayerStats.instance.rounds)
        {
            round++;
            _roundsSurvive.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
