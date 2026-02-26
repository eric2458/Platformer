using UnityEngine;
using UnityEngine.InputSystem;

public class Brick : MonoBehaviour
{
    public int pointsOnDestroy = 100;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!hit.gameObject.CompareTag("Player")) return;
        
        CharacterController controller = hit.gameObject.GetComponent<CharacterController>();
        if (controller == null) return;
        
        if (hit.moveDirection.y > 0.5f)
        {
            GameManager.Instance.AddCoin(1, pointsOnDestroy);
            Destroy(gameObject);
        }
    }
}