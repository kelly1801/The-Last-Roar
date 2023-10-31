using TMPro;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    #region serializedfield
    [SerializeField] private TMP_Text liveSecondsTextField;
    [SerializeField] private TMP_Text remainingEggsTextField;
    #endregion

    #region privatemethods
    private void FixedUpdate()
    {
        liveSecondsTextField.text = $"Live seconds: {GameManager.Instance.LiveSeconds}";
        remainingEggsTextField.text = $"{GameManager.Instance.EggsGoal}/{GameManager.Instance.EggsDropped}";
    }
    #endregion
}
