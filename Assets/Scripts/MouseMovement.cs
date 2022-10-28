using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Material _hidhlight;
    [SerializeField] private GameObject _shadow;

    private Material _default;
    private Renderer _renderer;
    private Vector3 _target;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _default = _renderer.material;
    }


    private void OnMouseEnter()
    {
        _renderer.material = _hidhlight;
    }

    private void OnMouseDown()
    {
        _shadow.SetActive(true);
        _shadow.transform.position = transform.position;
    }

    private void OnMouseUp()
    {
        _target = _shadow.transform.position;
        _shadow.SetActive(false);
    }

    private void OnMouseExit()
    {
        _renderer.material = _default;
    }
}