# UnityScripts
A collection of useful reusable scripts for Unity I've created for myself, which others are welcome to use.  
They are intended to be as minimal and straightforward as possible so they can be used for a variety of different projects, and they should be relatively easy to adjust for any differing requirements.  
The aim is to allow fast prototyping and game creation using a set of interchangeable modular scripts. For example, the player controllers will not include any camera controllers, so the creator can tweak every part independantly.  

If you want a new script created, log a new issue for it and I may get around to creating it.  
If you notice an issue with an existing script, also log an issue with details of how to reproduce it.  
*Note that I mostly develop in 2D so 3D scripts may take longer to be created.*

## Using/Installing the scripts
The scripts can be copied into your Unity project and should work without any further installation. Any exceptions/requirements of a script will be provided in the associated `README.md`.
Each of the scripts has detailed use case instructions in a `README.md` file located in the same directory.

# Scripts

## Camera
 - [Camera follower 2D](/CameraFollow2D) - Makes the camera smoothly follow an object or set of multiple objects
 - Camera follower 3D - WIP
 - [Screen shake 2D](/Screenshake2D) - Adds a screen shake effect applied to position and rotation
 - Screen shake 3D - WIP - Adds a screen shake effect applied to rotation only
 - Smooth zoom 2D - WIP
 - Frame objects 2D - WIP
 - Frame objects 3D - WIP
 - Side-scroller room camera 2D - WIP
 - Top-down room camera 2D - WIP

## Player controllers
### Top-down
 - [Top-down movement 2D](/TopDownMovement2D) - Makes a player GameObject move vertically and horizontally based on user input
 - Rotate to face mouse 2D - WIP
 - Top-down dash 2D - WIP
### Side-scroller
 - Side-scroller movement 2D - WIP
 - Side-scroller dash 2D - WIP
### Jumps
 - Better jump 2D - WIP - Implements better feeling jumping by moving away from realistic physics
 - Wall jump 2D - WIP
 - Coyote time - WIP - Allows the player to jump shortly after leaving a platform

## Other
 - Inventory system
