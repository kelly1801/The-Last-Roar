using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public delegate void OpenCrossfadeDelegate();
    public delegate void ExitCrossfadeDelegate();

    public OpenCrossfadeDelegate openCrossfadeEvent;
    public ExitCrossfadeDelegate exitCrossfadeEvent;

    private static UnityEvent onSceneChange;
    private static int scene;

    private ScenesManager instance;

    public static int Scene
    {
        get { return scene; }
        set
        {
            scene = value;
            onSceneChange.Invoke();
        }
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
    }

    private void Start()
    {
        scene = 0;

        SceneManager.sceneLoaded += OnEsceneLoaded;

        onSceneChange = new UnityEvent();
        onSceneChange.AddListener(OnSceneChanged);
    }

    private void OnEsceneLoaded(Scene scene, LoadSceneMode modo)
    {
        openCrossfadeEvent();
    }

    private void OnSceneChanged()
    {
        exitCrossfadeEvent();
    }
}
