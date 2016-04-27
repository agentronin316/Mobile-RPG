using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


    public float xMargin = 1.5f;
    public float yMargin = 1.5f;
    public float xSmooth = 1.5f;
    public float ySmooth = 1.5f;
    private Vector2 maxXAndY;
    private Vector2 minXAndY;
    public Transform player;


	void Awake ()
    {
        player = GameObject.FindWithTag("Player").transform;

        if(player == null)
        {
            Debug.LogError("Player object not found.");
        }

        Bounds backgroundBounds = GameObject.Find("Background").GetComponent<SpriteRenderer>().bounds;

        Vector3 cameraTopLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 cameraBottomRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f));

        minXAndY.x = backgroundBounds.min.x - cameraTopLeft.x;
        minXAndY.y = backgroundBounds.min.y - cameraBottomRight.y;
        maxXAndY.x = backgroundBounds.max.x - cameraBottomRight.x;
        maxXAndY.y = backgroundBounds.max.y - cameraTopLeft.y;

    }

    void LateUpdate()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;

        if (CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.fixedDeltaTime);
        }
        if (CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.fixedDeltaTime);
        }
            targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
            targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        transform.position = new Vector3(targetX, targetY);
    }


    /// <summary>
    /// Check if the player has moved near the edge of the camera bounds
    /// </summary>
    /// <returns>if the player has moved near the X edge of the camera</returns>
    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    /// <summary>
    /// Check if the player has moved near the edge of the camera bounds
    /// </summary>
    /// <returns>if the player has moved near the Y edge of the camera</returns>
    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }


}
