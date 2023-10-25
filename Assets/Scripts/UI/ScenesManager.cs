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
    private static int _scenesQuantity;

    private ScenesManager instance;

    [SerializeField] private int scenesQuantity;

    public static int ScenesQuantity
    {
        get => _scenesQuantity;
    }

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
        _scenesQuantity = scenesQuantity;

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
