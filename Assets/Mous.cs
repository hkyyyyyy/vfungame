using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mous : MonoBehaviour
{
    public enum RotationAxes2
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes2 axess = RotationAxes2.MouseXAndY;
    public float sensitivityHor2 = 9.0f;
    public float sensitivityVert2 = 9.0f;

    public float minimumVert2 = -15.0f;
    public float maximumVert2 = 45.0f;

    private float _rotationX = 0;

    // Use this for initialization
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axess == RotationAxes2.MouseX)
        {
            //horizontal rotation here
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor2, 0);
        }
        else if (axess == RotationAxes2.MouseY)
        {
            //Vertical rotation here
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert2;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert2, maximumVert2);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            //both horizontal and vertical rotation here
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert2;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert2, maximumVert2);
            float delta = Input.GetAxis("Mouse X") * sensitivityHor2;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
