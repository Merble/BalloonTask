using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class Balloon : MonoBehaviour
{
    [SerializeField] private MeshRenderer _MeshRenderer;
    [SerializeField] private float _MinSize;
    
    private SpringJoint _springJoint;

    public SpringJoint SpringJoint => _springJoint;

    public MeshRenderer MeshRenderer => _MeshRenderer;

    private void Awake()
    {
        _springJoint = GetComponent<SpringJoint>();
    }

    public void ScaleDown()
    {
        transform.localScale *= _MinSize;
    }
    
    public void ScaleUp(float duration)
    {
        var tween = LeanTween.scale(gameObject, Vector3.one, duration).setOnComplete(() =>
        {
            _springJoint.massScale = 1f;
        });
        tween.delay = duration / 5f;
    }
}
