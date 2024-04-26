using UnityEngine;

public class Reticle : MonoBehaviour
{
    [SerializeField]
    private RectTransform reticle;
    [SerializeField]
    private Transform target;

    private void Update()
    {
        var viewPort = Camera.main.WorldToViewportPoint(this.target.position);

        // Lock to screen bounds
        viewPort.x = Mathf.Clamp(viewPort.x, 0.0F, 1.0F);
        viewPort.y = Mathf.Clamp(viewPort.y, 0.0F, 1.0F);
        viewPort.z = 0.0F;

        // convert to screen position
        var screenPosition = Camera.main.ViewportToScreenPoint(viewPort);

        // move the reticle to the screen point
        this.reticle.position = screenPosition;
    }
}