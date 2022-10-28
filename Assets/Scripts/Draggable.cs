using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Collider _plane;

    private void Update()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 50f, 1) && hit.collider == _plane)
        {
            transform.position = Round(hit.point);
        }
    }

    private Vector3 Round(Vector3 vector)
    {
        return new Vector3(Mathf.Round(vector.x), Mathf.Round(vector.y), Mathf.Round(vector.z));
    }
}