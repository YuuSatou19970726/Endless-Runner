using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    public PlayerController player { get; private set; }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        player = FindObjectsByType<PlayerController>(FindObjectsSortMode.None).FirstOrDefault();
    }
}
