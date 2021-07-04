# CubeSurferClone

The project uses Unity-2021.1.12.f1

CubeSurferClone is a clone of the game from Playmarket:
 https://play.google.com/store/apps/details?id=com.Atinon.PassOver

![](Images/Gif.gif)

I'll start with a description of the level:

![](Images/1.png)

The entire level consists of only 3 components.

The Road.

![](Images/2.png)

The Walls.

![](Images/3.png)

And cubes that we can collect.

![](Images/4.png)

I optimized the walls a little, making them prefabs, and combining the colliders of all cubes.

![](Images/5.png)
![](Images/6.png)

Also, there is a bezier curve at the level indicating the direction.

![](Images/7.png)

--------------------------------------------------------------------------------------------------------------------------------------

Now let's talk a little about the player.

![](Images/8.png)

Тhis is his scene hierarchy.

![](Images/9.png)

* At the root is the PathFollower, when the game starts it starts to follow the path of the curve.
	In his childrance are the player and the camera:

	Camera does not have its own components, it only moves behind the point because it is in local coordinates

	Player has a component HorizontalMover that takes input from the joystick and moves the player to the left 
	and right in local coordinates.

	And also in Player childrance we have:
	
	CubesPool, which stores and can create CollectedCubes when told to do so.
	PlayerModel, it stores the 3d model of the player, in our case it is a ball.
	CollectableCubeFinder, which has a Trigger Collider and when it collides with CollectableCube then destroys it and tells the pool to create a CollectedCube
	Tail, only draws an orange tail after the player.


Let me remind you that the physics in the project is optimized and all unnecessary collisions are disabled, but all the necessary checks in OnTriggerEnters are still performed.

![](Images/10.png)
