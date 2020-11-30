# VR Project 2: BeeAMAZEd
Group Members:
* Joshua Williams
* Rahil Patel
* Trevor Pike
* Schafer Cunningham
## Project Proposal
https://docs.google.com/presentation/d/1qQ4-ICjIHno5b4hUp1YqKgLDHjFbx9KGk5eri1VJ3ys/edit?usp=sharing

## Project Description
Welcome to a VR maze game that has initially no escape from the maze. The ultimate goal is to find a key in the maze and take that key to the maze exit. However, the key and the maze exit are enclosed in an area that is not accessible to you intially. These two areas are enclosed by maze walls that will not let you pass. However, the maze has multiple powerups spread throughout that you can obtain and use to remove any specific maze wall such as the maze walls surrounding the two enclosed areas. There are multiple strategies that the user can use to escape the maze which we will explain in further details below.There are three main components to the maze.
* Using the powerups to reach the key area and the maze exit

![Image of PowerUp](https://cdn.discordapp.com/attachments/769945456021078079/782714120255438879/powerup.PNG)

* Obtaining the Key and taking it to the maze exit

![Image of Key](https://cdn.discordapp.com/attachments/769945456021078079/782746259953418240/key.PNG)

* Avoiding the bee swarm that is placed in the randomly generated Maze

![Image of BeeSwarm](https://cdn.discordapp.com/attachments/769945456021078079/782720107986157588/unknown.png)

## Key Area (Minigames)
The key area is one of the final areas of the game that you must unlock and complete in order to beat the game.  The only way to be able to beat the game is to obtain the key and to do this it is very important to complete the three mini games: Shooting Task, Wire Task, Basketball Task.  Once you complete the three games a golden key will appear on a table in the center of that room.  Once you pick up the key, you will be able to exit the maze thus beating the game.  

* This is what the key will look like with the completion of all the task:
![Image of Key](https://cdn.discordapp.com/attachments/769945456021078079/782753245193306153/Capture5.PNG)

### Shooting Task
To complete this task, you will have to pick up the Uzi that is placed on a table in the scene and shoot the moving punching bag dummy in the chest 10 times.  Make sure to pick up the Uzi with the left controller in order to shoot it properly.
![Image of ShootingTask](https://cdn.discordapp.com/attachments/769945456021078079/782753334649421884/Capture2.PNG)
### Wire Task
To complete this task, you will have to drag each of the color sliders to the end of their bar.  The controls for this part is pointing the included laser pointer at the color bar, hold down the button A on the right controller and dragging the cirlce to the end of the bar.
![Image of WireTask](https://cdn.discordapp.com/attachments/769945456021078079/782753292978749460/Capture3.PNG)
### Basketball Task
To complete this task, you will need to pick up the basketball with either hand and shoot it into the custom basketball hoop we made
![Image of BasketballTask](https://cdn.discordapp.com/attachments/769945456021078079/782753413997002762/Capture1.PNG)

## Maze Exit 
At the start of the game the maze has no finish.  You will spawn randomly in the maze and to be able to exit the maze you must find the powerups to remove the walls blocking the mini games.  Once you complete the mini games you will recieve the key to then be able to exit the maze thus completing the level.

## Powerups
In order to be able to complete the maze you will need to find the special powerups that are randomly spawned throughout the maze.  These powerups give the user the ability to remove whichever wall you want in the maze.  Since the game is all closed off at the start, it is necassary for the user to find and use these powerups to be able to complete the maze and win.

## Randomly Generated Maze 
The maze is generated randomly on each run, at any size, pre-determined by the programmer. The maze uses a "tree branching" algorithm, cosisting of the following steps:

- Choose a random starting spot
- Choose an adjacent cell
  - If the cell is already explored, place a wall between the current cell and the adjacent cell.
  - Else, initialize the cell and mark the edges of the cells as "passages" so a wall isn't placed between them.
- If there are no more adjacent cells, backtrack until there is an available adjacent cell.

The maze must also leave two "holes" for the tasks area and the maze's ending area. These coordinates are determined randomly, and are included in `ContainsCoordinates()`, a function which is called during maze generation to make sure the maze is still able to be solved with those "holes"


## Bee Swarm
Enemy AI that autonomously patrols the maze trying to find you and stop you from completing the level.  Goal is to avoid the Bee Swarm at all costs.

## Strategies
The strategies to completing the game is to quickly find the powerups that are randomly spawned throughout the maze.  Take it and find the end of the maze without being caught by the Bee Swarm that is patroling the map at random trying to find you.  Once you make it to the end of the maze, remove one of the walls that is blocking the last challange to complete with the found powerup.  Once you complete the 3 mini games the final key will spawn in.  Once you pick up the key, you are finally able to exit the maze.

## Issues Faced
Some of the issues that we faced during this project was mainly with Oculus' OVR controller support with our Unity enviornment.  One day it just stopped working and we were unable to fix the enviornment to get everything working again.  We reverted back to previous commits that we all made, however, that did not fix our problem.  We had to start a whole new project instead.  Another small issue that we ran into was getting the Oculus controllers to interact with Rigid Objects in the scene.  When these objects were picked up, they would float by the users feet rather than stay in their hands.  

## Contributions
* Joshua Williams

* Rahil Patel

* Trevor Pike

* Schafer Cunningham


## Resources Used

