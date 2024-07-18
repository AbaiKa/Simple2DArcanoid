using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ZoneComponent : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LineRenderer lineRenderer;

    [Header("Properties"), Space()]
    [SerializeField]
    [Range(0, 10)]
    private float rectangleSize;

    [Space()]
    public UnityEvent<Collider2D> onTrigger;

    public Vector3 TopLeft { get; private set; }
    public Vector3 TopRight { get; private set; }
    public Vector3 BottomRight { get; private set; }
    public Vector3 BottomLeft { get; private set; }


    private void Awake()
    {
        InitZone();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        onTrigger?.Invoke(collider);
    }
    private void OnDrawGizmosSelected()
    {
        InitZone();

        Gizmos.color = Color.red;

        Gizmos.DrawLine(TopLeft, TopRight);
        Gizmos.DrawLine(TopRight, BottomRight);
        Gizmos.DrawLine(BottomRight, BottomLeft);
        Gizmos.DrawLine(BottomLeft, TopLeft);
    }
    private void InitZone()
    {
        Vector2 screenBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.transform.position.z));

        TopLeft = new Vector2(-screenBounds.x, -screenBounds.y + rectangleSize);
        TopRight = new Vector2(screenBounds.x, -screenBounds.y + rectangleSize);
        BottomRight = new Vector2(screenBounds.x, -screenBounds.y);
        BottomLeft = new Vector2(-screenBounds.x, -screenBounds.y);

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        Vector3[] corners = new Vector3[2];

        corners[0] = TopLeft;
        corners[1] = TopRight;

        lineRenderer.positionCount = corners.Length;
        lineRenderer.SetPositions(corners);

        float x = Vector2.Distance(TopLeft, TopRight);
        float y = Vector2.Distance(TopLeft, BottomLeft);

        boxCollider.size = new Vector2(x, y);

        float centerX = (TopLeft.x + TopRight.x + BottomRight.x + BottomLeft.x) / 4;
        float centerY = (TopLeft.y + TopRight.y + BottomRight.y + BottomLeft.y) / 4;

        boxCollider.offset = new Vector2(centerX, centerY);
    }
}