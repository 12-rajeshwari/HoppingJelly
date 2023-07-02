# HoppingJelly Documentation
**This document helps to understand the game functionalities and Playing instructions:**

**Description**
This game aims to help our player Jelly reach the display stand by dogging or firing jelly capsules on our enemies (Cupcakes, doughnuts, croissants to serve, cheesecake and macaron tower). There are three levels in the game. Our player gets a total of 3 lives in each level. Whenever our player collides with an enemy, they lose a life, which will be indicated by changing the colour of the lower part of our player and at a left down screen, the remaining lives will be displayed.
The display stand is a level changer in the first and second levels. In the second and third levels, sliding platforms will help the player to reach the display stand. In the third level, when our player reaches the display stand, a pop-up message will say, "You won". If the player loses all their life, then there will be a pop-up message saying, "Game Over."

**Playing Instructions**
Player: Ocean Blue Object.
Enemies: Cupcakes, doughnuts, croissants to serve, cheesecake and macaron tower.
To jump: Press the "space" key on the keyboard
To fire capsules: Press the "e" key on the keyboard

**Techincal Details**
Prototype: Used the original prototype that was taught in the course.
Scenes: Start_Scene, level_2, Level_3
        Scripts: Scene_Changer and Final_level scripts were used to go to the next level.
                 Coin_script is used to display the "You won" message with the help of the OnTriggerEnter function.
        Materials: Imported Background, Level_2_background and level_3_background images were attached to the game scene background.
 
Platform: Material: Platform material is attached to all platforms in the game.
           Animation: With the help of animation, the movements of platforms were created.
           Script: The moving_platform script is used to attach the player to the moving platform.

Camera: There were two cameras used. One was attached to the player with the help of the Camera_Movement script, and the other was to display the entire game scene.
     Script: Camera_Movement

Player: Material: Player_mat material is attached to the cube and sphere of the player.
         Script: Player
Enemy: External asset perabs ( coffeeshop) was imported.
         Script: Enemy
Capsule: Material: Capsule_mat material is attached to fire bullets.
         Script: Capsule
SpawnManager: Script: Enemy script was used to generate random enemies.
UI_Manager: Script: UI_Manager script was used to display the status of the player. 

 **Functions:**
Start(), Update(), PlayerMovement(), Damage(), Color_channel(), Renderer(), Destroy(), gameOver(), win(), UpdateLives(), OnTriggerEnter(), Compare tag(), SceneManager(), SpawnManager(), UI_Manager(), GetRandomNumber(), OnPlayerDeath(), onPlayerWin(), IEnumerator SpawnSystem(), LateUpdate(), OnTriggerExit().

