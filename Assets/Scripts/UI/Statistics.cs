using TMPro;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    #region serializedfield
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_Text liveSecondsTextField;
    [SerializeField] private TMP_Text remainingEggsTextField;
    #endregion

    #region privatemethods
    private void FixedUpdate()
    {
        liveSecondsTextField.text = $"Live seconds: {gameManager.LiveSeconds}";
        remainingEggsTextField.text = $"{gameManager.EggsGoal}/{gameManager.EggsDropped}";
    }
    #endregion
}
