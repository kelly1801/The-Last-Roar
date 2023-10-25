using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public event EventHandler GameOver;
    public event EventHandler Victory;
    public event EventHandler EggPicked;

    [SerializeField] private int _eggsGoal = 1;
    [SerializeField] private int liveMinutes = 5;

    private static GameManager instance;

    private static int eggsGoal = 0;
    private static int liveSeconds = 0;
    private static int eggsDropped = 0;

    public static int EggsGoal { get => eggsGoal; }
    public static int LiveSeconds { get => liveSeconds; }
    public static int EggsDropped { get => eggsDropped; set => eggsDropped = value; }

    private bool victoryTriggered = false;


    public static GameManager Instance
    {
        get { return instance; }
    }

    public static bool Pause
    {
        get { return Time.timeScale == 0; }
        set { if (value) { Time.timeScale = 0; } else { Time.timeScale = 1; } }
    }

    public void OnEggPicked()
    {
        EggPicked?.Invoke(this, EventArgs.Empty);
    }

    public void OnGameOver()
    {
        GameOver?.Invoke(this, EventArgs.Empty);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        OnEggPicked();
    }

    private void Start()
    {
        eggsGoal = _eggsGoal;
        eggsDropped = 0;
        StartCoroutine(StartTimer(liveMinutes));
    }

    private void FixedUpdate()
    {
        if (eggsDropped == eggsGoal && !victoryTriggered)
        {
            victoryTriggered = true;
            OnVictory();
        }
    }

    private void OnVictory()
    {
        Victory?.Invoke(this, EventArgs.Empty);
    }

    private IEnumerator StartTimer(int liveMinutes)
    {
        liveSeconds = liveMinutes * 60;

        while (liveSeconds > 0)
        {
            yield return new WaitForSeconds(1f);
            liveSeconds -= 1;
        }

        OnGameOver();
    }
}
