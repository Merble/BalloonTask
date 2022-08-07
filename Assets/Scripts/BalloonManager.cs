using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BalloonManager : MonoBehaviour
{
    [SerializeField] private Balloon _BalloonPrefab;
    [SerializeField] private FixedPoint _FixedPoint;
    [SerializeField] private List<Material> _Materials;
    [Space]
    [SerializeField] private float _BalloonSpawnIntervalDuration;
    [SerializeField] private float  _BalloonScaleUpDuration;
    [SerializeField] private int _BalloonCount;

    private void Start()
    {
        StartCoroutine(CreateBalloonsRoutine());
    }

    private IEnumerator CreateBalloonsRoutine()
    {
        var count = _BalloonCount;

        while (count > 0)
        {
            yield return new WaitForSeconds(_BalloonSpawnIntervalDuration);

            CreateBalloons();

            count--;
        }
    }
    
    private void CreateBalloons()
    {
        var balloon = Instantiate(_BalloonPrefab, _FixedPoint.transform.position, Quaternion.identity);
        
        balloon.ScaleDown();
        balloon.SpringJoint.connectedBody = _FixedPoint.Rigidbody;
        balloon.SpringJoint.massScale = 1f;
        
        var randomNumber = Random.Range(0, _Materials.Count);
        balloon.MeshRenderer.material = _Materials[randomNumber];
        
        balloon.ScaleUp(_BalloonScaleUpDuration);
    }
}
