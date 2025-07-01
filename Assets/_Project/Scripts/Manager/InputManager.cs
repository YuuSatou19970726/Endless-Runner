using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;

    public bool isKeySpace { get; private set; }
    public bool isMouseLeftClick { get; private set; }
    public bool isMouseRightClick { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        this.ApplyAssignInput();
        this.ApplyMouseClick();
    }

    private void ApplyAssignInput()
    {
        // this.isKeySpace = Input.GetKeyDown(KeyCode.Space);
        this.isKeySpace = Input.GetButtonDown(InputTags.JUMP);
    }

    private void ApplyMouseClick()
    {
        this.isMouseLeftClick = Input.GetButtonDown(InputTags.FIRE_1);
        this.isMouseRightClick = Input.GetButtonDown(InputTags.FIRE_2);
    }
}
