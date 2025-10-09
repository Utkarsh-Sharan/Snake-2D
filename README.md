# Snake-2D
Classic 2D Snake Game in Unity 🎮
Welcome to the Classic 2D Snake Game project! This Unity-based game brings the timeless Snake experience with some exciting features and enhancements. Below is a detailed overview of the game and its features.

## ⚠️ **Archived Project Notice**  
This Unity project is no longer maintained and may contain unpatched binaries affected by CVE-2025-59489.  
Please do not use or distribute without applying Unity’s official security patch.

🚀 Features

🕹️ Core Gameplay

Objective: Collect good food to increase your score and body length while avoiding collisions with your own body.
Game Over: The game ends if the snake collides with itself.

High Score Tracking 🏆

Implementation: High scores are saved and loaded using JSON, keeping track of player names and scores.

Main Menu UI Animations 🎨

Tools Used: Unity’s Timeline feature is used to create engaging animations for the Main Menu UI.

Game Modes 🎮

Single Player: Play solo and try to beat your high score.

Local Co-Op: Two players can compete against each other on the same screen.

Food Types 🍎🍄

Apple (Good Food): Increases score by 5 and lengthens the snake.

Mushroom (Bad Food): Decreases score by 5 and shortens the snake. If the snake’s length is at the minimum, eating a mushroom will eliminate the player.

Powerups ✨

Score Booster: Temporarily increases the score gained from eating apples to 10 points for 5 seconds.

Shield: Provides invulnerability against self-collisions for 5 seconds.

Sound Effects 🔊

Powerup Pickup: A sound plays when a player picks up a powerup.

Powerup Deactivation: Sound indicates when a powerup’s effect has ended.

Button Clicks: Audio feedback for interactions with menu buttons.

Food Eating: Sound for when the snake eats food (apple or mushroom).

Game Over: An audio cue signals the end of the game.

Co-Op Player Death Logic 👾

Head-to-Body Collision: If Player 1’s head collides with Player 2’s body, Player 1 wins, and vice versa.

Head-to-Head Collision: Results in a draw if both players collide head-on.

Shield Interaction: If Player 1 has collected a shield powerup, Player 2’s collision with Player 1’s body will not eliminate Player 1, and the game continues.

Watch Gameplay here: https://www.loom.com/share/2ec9442ed9964868b14c118471a20353?sid=af1e1ad6-1512-4b9f-9333-e11b7dd6df0d
