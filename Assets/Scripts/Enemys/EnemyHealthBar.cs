using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private MaterialPropertyBlock _matBlock;
    private MeshRenderer _meshRenderer;
    private Camera _mainCamera;
    private Enemy _enemy;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _matBlock = new MaterialPropertyBlock();
        _enemy = GetComponentInParent<Enemy>();
    }

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_enemy.CurrentHealth < _enemy.MaxEnemyHealth)
        {
            _meshRenderer.enabled = true;
            AlignCamera();
            UpdateParams();
        }
        else
        {
            _meshRenderer.enabled = false;
        }
    }

    private void UpdateParams()
    {
        _meshRenderer.GetPropertyBlock(_matBlock);
        _matBlock.SetFloat("_Fill", _enemy.CurrentHealth / (float)_enemy.MaxEnemyHealth);
        _meshRenderer.SetPropertyBlock(_matBlock);
    }

    private void AlignCamera()
    {
        if (_mainCamera != null)
        {
            var camXform = _mainCamera.transform;
            var forward = transform.position - camXform.position;
            forward.Normalize();
            var up = Vector3.Cross(forward, camXform.right);
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }

}
