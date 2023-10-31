using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public event EventHandler GameOverEvent;
    public event EventHandler VictoryEvent;
    public event EventHandler EggPickedEvent;

    [SerializeField][Min(0)] private int _eggsGoal = 1;
    [SerializeField][Min(0)] private float liveMinutes = 5;

    private static bool gameOver = false;
    public static bool GameOver { get => gameOver; set => gameOver = value; }

    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    public delegate void PauseDelegate();
    public static event PauseDelegate OnPauseEvent;

    private int eggsGoal = 0;
    private int liveSeconds = 0;
    private int eggsDropped = 0;

    public int EggsGoal { get => eggsGoal; }
    public int LiveSeconds { get => liveSeconds; }
    public int EggsDropped { get => eggsDropped; set => eggsDropped = value; }

    private bool victoryTriggered = false;

    public static bool Pause
    {
        get { return Time.timeScale == 0; }
        set { if (value) { Time.timeScale = 0; } else { Time.timeScale = 1; } OnPaused(); }
    }

    public static void OnPaused()
    {
        OnPauseEvent?.Invoke();
    }

    public void OnEggPicked()
    {
        EggPickedEvent?.Invoke(this, EventArgs.Empty);
    }

    public void OnGameOver()
    {
        GameOverEvent?.Invoke(this, EventArgs.Empty);
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

        StartVariables();
        OnEggPicked();
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
        VictoryEvent?.Invoke(this, EventArgs.Empty);
    }

    private IEnumerator StartTimer(float liveMinutes)
    {
        liveSeconds = (int)(liveMinutes * 60);

        while (liveSeconds > 0)
        {
            yield return new WaitForSeconds(1f);
            liveSeconds -= 1;
        }

        OnGameOver();
    }

    private void StartVariables()
    {
        gameOver = false;
        eggsGoal = _eggsGoal;
        eggsDropped = 0;
        StartCoroutine(StartTimer(liveMinutes));
    }
}
