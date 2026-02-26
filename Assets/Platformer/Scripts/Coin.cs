using UnityEngine;
using UnityEngine.InputSystem;

public class Coin : MonoBehaviour
{
    public int points = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        GameManager.Instance.AddCoin(1, points);
        Destroy(gameObject);

        Debug.Log("Coin collected!");
    }
}