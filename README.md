# RoleAnalysis1
*A project around creating a movement system in Unity and C#. The theme is Spiderman like movement, only in 2D.*

## Controls, *subject to change!*
- A and D keys for left and right movement
- W and Space for jump
- Right mouse click will zip to the point nearest to the mouse
- Left mouse click will connect to the nearest point and then swing
- *if there's enough time,* moving and hitting the S key will slide

## Inspiration
After playing all of Insomniac's Spiderman series, I decided I was going to try to mimic the web swinging on a 2D scale.

## Biggest challenge
One of the biggest challenges I foresee is that finding out which point is closest to the mouse at any given point is going to be quite an expensive operation for Unity. I also am unsure of how to create the zipping or swinging mechanics from a physics perspective which I need more research into. Other than that, I don't see an issue.

## Algorithm at a Glance
Essentially, the mouse will have a game object with a collider connected to it. When it collides with any point, the mouse will send that data to the player. That way, only the closest points ever get evaluated. To calculate these distances, raycasts will be sent out and their lengths will be saved, that way we can determine if it's close enough for the player to even grapple. From there, it's just basic physics programming!

# Devlogs
### [Update 1](https://github.com/mmhamman/RoleAnalysis1/commit/010cfc474ccccb19d9a19a5a9232463a741d5ddc) Created Unity Project and background
- Not much progress except Ideation offline and creating a general template. There really isn't much else to say.
---
