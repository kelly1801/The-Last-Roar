using UnityEngine;

public class CinematicLoader : MonoBehaviour
{
    #region serializedfields
    [SerializeField] private GameObject goodEnding;
    [SerializeField] private GameObject badEnding;
    [SerializeField] private CinematicType type = CinematicType.None;
    #endregion

    #region privatefields
    private enum CinematicType
    {
        None,
        Good,
        Bad
    }
    #endregion

    #region privatemethods
    private void Start()
    {
        if (type == CinematicType.None)
        {
            ExecuteByPlayer();
        }
        else
        {
            ExecuteByType();
        }
    }

    private void ExecuteByPlayer()
    {
        if (PlayerController.IsDead)
        {
            PlayBadEnding();
        }
        else
        {
            PlayGoodEnding();
        }
    }

    private void ExecuteByType()
    {
        switch (type)
        {
            case CinematicType.Good:
                PlayGoodEnding();
                break;
            case CinematicType.Bad:
                PlayBadEnding();
                break;
        }
    }

    private void PlayGoodEnding()
    {
        goodEnding.SetActive(true);
        badEnding.SetActive(false);
    }

    private void PlayBadEnding()
    {
        goodEnding.SetActive(false);
        badEnding.SetActive(true);
    }
    #endregion
}
