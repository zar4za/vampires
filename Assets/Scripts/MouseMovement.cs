using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private Material _hidhlight;
    [SerializeField] private GameObject _shadow;
    [SerializeField] private float _speed = 1f;

    private Material _default;
    private Renderer _renderer;
    private Vector3 _target;
    private bool _interactable = true;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        _default = _renderer.material;
        _speed = 1 / _speed;
    }

    private void OnMouseOver()
    {
        if (!_interactable) return;
        
        _renderer.material = _hidhlight;
    }

    private void OnMouseDown()
    {
        if (!_interactable) return;

        _shadow.SetActive(true);
        _shadow.transform.position = transform.position;
    }

    private void OnMouseUp()
    {
        if (!_interactable) return;

        _interactable = false;
        _target = _shadow.transform.position;
        _shadow.SetActive(false);

        var length = Mathf.Clamp((_target - transform.position).magnitude * _speed, 1f, 5f);
        transform.DOMove(_target, length).SetEase(Ease.InOutCubic).OnComplete(SetInteractable);
    }

    private void OnMouseExit()
    {
        if (!_interactable) return;
        _renderer.material = _default;
    }

    private void SetInteractable()
    {
        _interactable = true;
    }
}