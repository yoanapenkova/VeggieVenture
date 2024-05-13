using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public static CursorManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Ya existe una instancia de CursorManager. Destruyendo duplicado.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // Al iniciar, asegúrate de que el cursor esté visible
        Cursor.visible = true;
    }

    public void ShowCursor()
    {
        // Muestra el cursor
        Cursor.visible = true;
    }

    public void HideCursor()
    {
        // Oculta el cursor
        Cursor.visible = false;
    }
}
