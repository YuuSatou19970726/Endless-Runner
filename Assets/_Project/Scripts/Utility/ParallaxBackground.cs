using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    private GameObject cameraMain;

    [SerializeField] private float parallaxEffect;

    private float length;
    private float xPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.cameraMain = GameObject.Find(GameObjectTags.MAIN_CAMERA);

        this.length = GetComponent<SpriteRenderer>().bounds.size.x;

        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = this.cameraMain.transform.position.x * (1 - this.parallaxEffect);
        float distanceToMove = this.cameraMain.transform.position.x * this.parallaxEffect;

        transform.position = new Vector3(this.xPosition + distanceToMove, transform.position.y);

        if (distanceMoved > this.xPosition + this.length)
        {
            xPosition += this.length * 2;
        }
    }
}
