using UnityEngine;

public class CinematicLoader : MonoBehaviour
{
    private enum CinematicType
    {
        None,
        Happy,
        Sad
    }

    [SerializeField] private GameObject happyEnding;
    [SerializeField] private GameObject sadEnding;
    [SerializeField] private CinematicType type = CinematicType.None;

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
        if (PlayerController.GameOver)
        {
            happyEnding.SetActive(false);
            sadEnding.SetActive(true);
        }
        else
        {
            happyEnding.SetActive(true);
            sadEnding.SetActive(false);
        }
    }

    private void ExecuteByType()
    {
        switch (type)
        {
            case CinematicType.Happy:
                happyEnding.SetActive(true);
                sadEnding.SetActive(false);
                break;
            case CinematicType.Sad:
                happyEnding.SetActive(false);
                sadEnding.SetActive(true);
                break;
        }
    }
}
