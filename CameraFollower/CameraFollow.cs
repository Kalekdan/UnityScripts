using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _xLerpSpeed, _yLerpSpeed;
    [SerializeField] private GameObject _initialFocus;

    private static GameObject[] _pointsOfFocus;

    private Vector2 _targetPos;

    private void Start()
    {
        setPointsOfFocus(new[] {_initialFocus});
    }

    private void Update()
    {
        _targetPos = avgPosition(_pointsOfFocus);
        lerpCamera(_targetPos);
    }

    private Vector2 avgPosition(GameObject[] points)
    {
        var xPos = 0.0f;
        var yPos = 0.0f;
        var numPoints = points.Length;

        foreach (var point in points)
        {
            xPos += point.transform.position.x;
            yPos += point.transform.position.y;
        }

        xPos /= numPoints;
        yPos /= numPoints;
        return new Vector2(xPos, yPos);
    }

    private void lerpCamera(Vector2 target)
    {
        var newX = Mathf.Lerp(transform.position.x, target.x, _xLerpSpeed * Time.deltaTime);
        var newY = Mathf.Lerp(transform.position.x, target.x, _yLerpSpeed * Time.deltaTime);
        var newZ = transform.position.z;

        transform.position = new Vector3(newX, newY, newZ);
    }

    public static GameObject[] getPointsOfFocus()
    {
        return _pointsOfFocus;
    }

    public static void setPointsOfFocus(GameObject[] points)
    {
        _pointsOfFocus = points;
    }
}
