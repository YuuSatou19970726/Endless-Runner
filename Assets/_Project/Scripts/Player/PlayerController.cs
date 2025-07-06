using UnityEngine;

public class PlayerController : CustomMonoBehaviour
{
    public Transform playerBody;

    public Animator animator { get; private set; }

    protected override void LoadComponents()
    {
        this.MappingComponent();
    }

    private void MappingComponent()
    {
        if (animator != null) return;
        animator = GetComponentInChildren<Animator>();
    }
}
