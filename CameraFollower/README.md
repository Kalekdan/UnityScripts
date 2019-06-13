# Camera Follower

## About

This script makes the camera smoothly follow an object or a selection of objects.  

## Using

 - Attach the script to a camera object.  
 - Set the x lerp speed and the y lerp speed in the inspector (5 is normally a good starting point).  
 - Higher values will make the camera snap to the object quicker in that axis.  
 - Set the object(s) to focus on
   - In the inspector, by increasing the array size and dragging the objects in
   - Using the function ```SetPointsOfFocus(GameObject[] points)```

The camera will follow the average location of all the points of focus. If you want more weighting towards a specific object (i.e. the player), add multiple occurences of their GameObject to the array of points of focus.
