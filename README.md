# RoleAnalysis1
*A project around creating a movement system in Unity and C#. The theme is Spiderman like movement, only in 2D.*

*[To skip to devlogs, click here!](https://github.com/mmhamman/RoleAnalysis1/blob/main/README.md#devlogs)*

## Controls, *subject to change!*
- A and D keys for left and right movement
- W and Space for jump
- Right mouse click will zip to the point nearest to the mouse
- Left mouse click will connect to the nearest point and then swing
- *if there's enough time,* moving and hitting the S key will slide

## Inspiration
![Spiderman webswinging](https://github.com/mmhamman/RoleAnalysis1/assets/89564033/3d4e0ade-efc1-4d87-869a-3cb775a45f98)

After playing all of Insomniac's Spiderman series, I decided I was going to try to mimic the [web swinging](https://www.youtube.com/watch?v=YpJRWbUCTJg) on a 2D scale. 

I also am not fully recreating Spiderman and all of his abilities, just the ability to move on a 2-dimensional plane, zip to a point, and swing from a point.

## Biggest challenge
One of the biggest challenges I foresee is that finding out which point is closest to the mouse at any given point is going to be quite an expensive operation for Unity. I also am unsure of how to create the zipping or swinging mechanics from a physics perspective which I need more research into. Other than that, I don't see an issue.

## Algorithm at a Glance
Essentially, the mouse will have a game object with a collider connected to it. When it collides with any point, the mouse will send that data to the player. That way, only the closest points ever get evaluated. To calculate these distances, raycasts will be sent out and their lengths will be saved, that way we can determine if it's close enough for the player to even grapple. From there, it's just basic physics programming!

------

# Devlogs
## A Note about the Devlogs
- They are all going to contain links to commits in this project. The intention is that full updates to the game will be noted here; otherwise, my commits are just for saving so they might not fully articulate all work that was changed but may just be a brief few words to remind myself what was changed.

### [Update 1](https://github.com/mmhamman/RoleAnalysis1/commit/010cfc474ccccb19d9a19a5a9232463a741d5ddc) Created Unity Project and background
- Not much progress except Ideation offline and creating a general template. There really isn't much else to say.
---
### [Update 2](https://github.com/mmhamman/RoleAnalysis1/commit/dd7d064eb206f49d8d4d5d87bbe82c29e34d164d) Left and Right Movement Complete
- Player can now move left and right with either the A and D keys or left and right arrows. Drag and acceleration have been fully applied as well when on ground.
- There are a few bugs but it's mostly with drag and how it may be achieving the correct effect but it's not achieving said effect the correct way
---
### [Update 3](https://github.com/mmhamman/RoleAnalysis1/commit/bc98fdbd1d83c3bc8db82768657a5ef6b494f6b9) Drag Bug Fixes and Turning Velocity Implemented
- There was no set behavior for if the player was moving and then abruptly turned and so now whenever the player is moving in one direction and wishes to move to the next, the player velocity will be reset to 0.
---
### [Update 4](https://github.com/mmhamman/RoleAnalysis1/commit/28cbb42763bc62eba77c90ac178fbf31d50a6e34) Added smooth camera tracking
- There was no camera tracking before hand but now the player can move and get followed by the camera. This was achieved by adding 2 offsets. A Y offset so the player can look up to see pegs to zip to and an x offset to look ahead of the player dependant on how fast the player is moving.
- The equation I used for camera position is a simple calculus problem where the x position is equal to the position of the player divided by the derivative of the horizontal speed of the player.
