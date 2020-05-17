# Blobs 2D

This is a 2d game in which you should kill all opposing players in order to win. It is based on the [Isometric TileMap](https://docs.unity3d.com/Manual/Tilemap-Isometric.html) system introduced by Unity with 2018.3 version .
All environmental assests are provided in the Unity [example project](https://drive.google.com/file/d/12odxbzFZmdOoknEHVnqA80vOrVU5nzzI/view).

All the blobs and animations are designed using Asprite for this project.

<img src="https://github.com/chamikaCN/Blobs/blob/master/ReadME%20Contents/SimpleBlob_Orange_Front.gif" width="150px"> <img src="https://github.com/chamikaCN/Blobs/blob/master/ReadME%20Contents/SimpleBlob_Blue_Side.gif" width="150px">

### Gameplay

At the start menu player will be asked to pick a team (**Blue** or **Orange**) .The game will start with 12 blobs randomly placed in the scene with 6 blobs per each team.
Player can only control single blob. All other Blobs will be controlled by scripts. Player selected blob can attack enemy blobs while getting away from their fireballs.
Player can **switch** the control at any time among all the blobs of same team. If the blob controlled by the player dies control **will be automatically switched** to a remaining player.
The team which destroy all enemy blobs win the game.

![Screenshot](https://github.com/chamikaCN/Blobs/blob/master/ReadME%20Contents/Capture.PNG)

### Other Details

This project was redesigned and continued as a 3d project with the same scheme in [DroidLand](https://github.com/chamikaCN/DroidLand)
