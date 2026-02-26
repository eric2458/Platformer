using UnityEngine;
using UnityEngine.InputSystem;
public class MarioBrickHit : MonoBehaviour
{
    public int brickPoints = 100;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!hit.collider.CompareTag("Brick"))
            return;

        // Make sure Mario is below the brick
        if (transform.position.y >= hit.collider.bounds.center.y)
            return;

        if (hit.moveDirection.y <= 0f)
            return;

        // Give 1 coin + 100 points
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCoin(1, brickPoints);
        }

        Destroy(hit.collider.gameObject);

        Debug.Log("Brick hit! +1 coin and +" + brickPoints + " points");
    }
}
