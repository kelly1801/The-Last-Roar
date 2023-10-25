using TMPro;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    [SerializeField] private TMP_Text liveSecondsTextField;
    [SerializeField] private TMP_Text remainingEggsTextField;

    private void FixedUpdate()
    {
        liveSecondsTextField.text = $"Live seconds: {GameManager.LiveSeconds}";
        remainingEggsTextField.text = $"{GameManager.EggsGoal}/{GameManager.EggsDropped}";
    }
}
