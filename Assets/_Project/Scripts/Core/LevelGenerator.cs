using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform[] levelPart;
    [SerializeField] private Vector3 nextPartPosition;

    [SerializeField] private float distanceToSpawn;
    [SerializeField] private float distanceToDelete;
    private Transform player;

    private void Start()
    {
        this.player = GameManager.Instance.player.playerBody;
    }

    private void Update()
    {
        this.GeneratePlatform();
        this.DeletePlatform();
    }

    private void GeneratePlatform()
    {
        if (this.player == null) return;
        while (Vector2.Distance(this.player.transform.position, this.nextPartPosition) < this.distanceToSpawn)
        {
            Transform part = this.levelPart[Random.Range(0, this.levelPart.Length)];
            Vector3 startPartPosition = part.Find(GameObjectTags.START_POINT).position;
            Vector2 newPosition = new Vector2(this.nextPartPosition.x - startPartPosition.x, 0);
            Transform newPart = Instantiate(part, newPosition, transform.rotation, transform);
            this.nextPartPosition = newPart.Find(GameObjectTags.END_POINT).position;
        }
    }

    private void DeletePlatform()
    {
        if (transform.childCount > 0)
        {
            Transform partToDelete = transform.GetChild(0);

            if (Vector2.Distance(player.transform.position, partToDelete.transform.position) > this.distanceToDelete)
                Destroy(partToDelete.gameObject);
        }
    }
}
