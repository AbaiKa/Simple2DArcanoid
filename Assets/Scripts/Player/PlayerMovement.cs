using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform model;
    [SerializeField] private ZoneComponent movementZone;

    private float speed;

    public void Init(float speed)
    {
        this.speed = speed;
    }
    public void Move(Vector2 direction)
    {
        Vector3 position = new Vector3(direction.x, direction.y) * speed * Time.deltaTime;
        Vector3 newPosition = model.localPosition + position;

        float scaleOffset = model.localScale.x / 2;

        float x = Mathf.Clamp(newPosition.x, movementZone.TopLeft.x + scaleOffset, movementZone.TopRight.x - scaleOffset);
        float y = Mathf.Clamp(newPosition.y, movementZone.BottomLeft.y + scaleOffset, movementZone.TopRight.y - scaleOffset);

        model.localPosition = new Vector3(x, y);
    }
}