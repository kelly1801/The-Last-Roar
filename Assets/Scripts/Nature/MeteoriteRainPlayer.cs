using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MeteoriteRainPlayer : MonoBehaviour
{
    #region serializedfields
    [SerializeField] MeteoriteRain meteoriteRain;
    #endregion

    #region privatemethods
    private void Start()
    {
        meteoriteRain.Run();
    }
    #endregion
}
