using UnityEngine;
using UnityEngine.InputSystem;
public class CameraMovement : MonoBehaviour
{
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0f;
        if (Keyboard.current.leftArrowKey.isPressed)
            move = -1f;
        else if(Keyboard.current.rightArrowKey.isPressed)
            move = 1f;
        if(move != 0f)
            transform.position += new Vector3(move * speed * Time.deltaTime, 0, 0);
    }
}
