using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshakeController : MonoBehaviour
{
    public Transform PlayerTransform;
    public float HorizontalLerpRate, VerticalLerpRate;

    private Vector3 _targetPosition;
    private Vector3 _cameraPosition;
	
    //Screen shake variables
    private Vector3 _screenshakeOffset;
    private Vector3 _screenshakeAngleOffset;
    public float TraumaDecayRate = 1;
    public float MinTrauma = 0.1f;
    [SerializeField]
    private float _trauma = 1.5f;
    private float _screenShakeAmount;
    public float MaxAngle, MaxOffset;
    private float _angle, _xOffset, _yOffset;
	
    // Use this for initialization
    void Start ()
    {
        _cameraPosition = transform.position;
        _screenshakeOffset = new Vector3(0, 0, 0);
    }
	
    // Update is called once per frame
    void Update ()
    {

        _targetPosition = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, _cameraPosition.z);
        _cameraPosition = new Vector3(Mathf.Lerp(_cameraPosition.x, _targetPosition.x, HorizontalLerpRate * Time.deltaTime),
            Mathf.Lerp(_cameraPosition.y, _targetPosition.y, VerticalLerpRate * Time.deltaTime), _cameraPosition.z);
		
        transform.position = _cameraPosition + _screenshakeOffset;
        transform.eulerAngles = _screenshakeAngleOffset;
    }

    private void FixedUpdate()
    {
        _screenShakeAmount = _trauma * _trauma;
        applyScreenshake();
        decayTrauma();
        _screenshakeOffset = new Vector3(_xOffset, _yOffset, 0);
        _screenshakeAngleOffset = new Vector3(0, 0, _angle);
    }

    public void addTrauma(float amount)
    {
        _trauma += amount;
    }

    private void decayTrauma()
    {
        if (_trauma > 0)
        {
            _trauma -= TraumaDecayRate;
        }
        if (Mathf.Abs(_trauma) < MinTrauma) _trauma = 0;
    }

    private void applyScreenshake()
    {
        _angle = MaxAngle * _screenShakeAmount * (Mathf.PerlinNoise(Random.value, 0.0F)-0.5f);
        _xOffset = MaxOffset * _screenShakeAmount * (Mathf.PerlinNoise(Random.value, 0.0F)-0.5f);
        _yOffset = MaxOffset * _screenShakeAmount * (Mathf.PerlinNoise(Random.value, 0.0F)-0.5f);
    }
}
