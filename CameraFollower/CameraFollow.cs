using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Camera lerp speed - Higher values will mean camera travels
    // faster in that axis towards its target
    [SerializeField] private float _xLerpSpeed, _yLerpSpeed;

    // Array of GameObject for the camera to focus on
    // Finds the average position of all objects in the array
    // For a weighted focus (e.g. towards a player), add them
    // To the array multiple times
    [SerializeField] private GameObject[] _pointsOfFocus;

    private Vector2 _targetPos;

    private void Update()
    {
        _targetPos = AvgPosition(_pointsOfFocus);
        LerpCamera(_targetPos);
    }

    // Returns the average position of all the GameObjects in the array
    private Vector2 AvgPosition(GameObject[] points)
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

    // Smoothly lerp the camera towards the target location
    // Keeps the z coordinate the same
    private void LerpCamera(Vector2 target)
    {
        var newX = Mathf.Lerp(transform.position.x, target.x, _xLerpSpeed * Time.deltaTime);
        var newY = Mathf.Lerp(transform.position.y, target.y, _yLerpSpeed * Time.deltaTime);
        var newZ = transform.position.z;
        
        transform.position = new Vector3(newX, newY, newZ);
    }

    // Returns the array of GameObjects which are the focus points
    // Can be useful if you wish to add a single item to the existing array of points
    public GameObject[] getPointsOfFocus()
    {
        return _pointsOfFocus;
    }

    // Sets the GameObject array to the value passed 
    public void SetPointsOfFocus(GameObject[] points)
    {
        _pointsOfFocus = points;
    }
}
