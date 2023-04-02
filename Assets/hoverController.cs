using UnityEngine;
public class hoverController : MonoBehaviour
{
    public float hoverHeight = 0.5f;   // distance to hover above ground
    public float hoverSpeed = 1.0f;    // speed of hovering movement
    public float hoverRange = 0.2f;    // maximum distance to hover from starting position

    private Vector3 startPos;          // starting position of the object

    void Start()
    {
        // get the starting position of the object
        startPos = transform.position;
    }

    void Update()
    {
        // calculate the target position for hovering
        Vector3 targetPos = startPos + new Vector3(0, Mathf.Sin(Time.time * hoverSpeed) * hoverRange, 0);

        // move the object towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);

        // adjust the object's y position to hover above the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float distanceToGround = hit.distance;
            float hoverError = hoverHeight - distanceToGround;
            transform.position += new Vector3(0, hoverError, 0);
        }
    }
}