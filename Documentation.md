# Aim-for-the-hole

https://github.com/Hris21/Aim-for-the-hole

Documentation date update 03/03/2015

This is the documentation for the game Aim For The Hole - chosen by consensus between the programmers and the leader.
The project main goal was to to put the combined efforts of all the members, thus resulting in great teamwork and results.
In this program the following people have taken part: 
Y.Maltsiev(Яни Малцев), shunobaka(Веселин Минев), veselints(Веселин Цветанов), yordansg(Йордан Георгиев), kabumko(Теодор Архондаки), success(Христо Кокалов), toshocorp(Тодор Павлов), Hristiyan_Andreev(Християн Андреев).

--------------------------------------------------------------------------------

Main idea of the game:

The game consists of a main menu, board, a hero, falling lines and bonuses.
Every line has a hole which is placed at a random spot and the player must go
through the hole in order to avoid colliding with the wall. Every time the hero
goes through a hole, he receives points which are used to calculate the level of
the player and make the lines fall faster. The player may also collect bonuses
represented by the plus symbol (+) which reward ten times more points than going
through a line. The bonuses are always placed at a random spot along the board's
width and in the middle between two lines. If the player fails to avoid collision
the game screen turns red, says the game is over and waits for the player to press
enter. Then the player is asked for name and the top10 scores are saved. The game
provides the player with an extremely user-friendly experience including:

- easy to navigate and understand main menu
- options to help the player resize the game board according to one's preferences
- highscore button which lets the player see the scores of the other players
- exit button followed by confirmation to avoid closing the game by mistake

--------------------------------------------------------------------------------

General rules for the game are:

To have 1 or more multy-dimensional arrays!

1

We have 1 multy-dimensional char array called board, which is used to visualize our play-field border.
The board stars as a field of 35 by 20.
The array is used in the Border method which sets the char value to a symbol that represents the field.
The Border method also sets the first initiation of the line that is supposed to kill the hero, and the heros position. 

To have 3 or more one-dimensional arrays!

2.1

We have size array which sets the size for the border array, it is used in setting starting value of players and bonus position.
Trough the starting menu it can be set to different values, if the game is started the values that are now present in the array are used to shape the play field.
That array is mostly used to set a limit to where the objects should be and where not!!!
It is used in the Options method to set size for the border as we said before, and to rescale the console so the program works correctly.

2.2

The playerPossition array is the one that saves the values of that where the player is located on the board.
It is used to set the board through the Board method, and in the PlayerPosition method.
In PlayerPosition method it is used to move the player depending on the buttons pressed in the correct direction if possible.
It is used in the options analogically as size array. One changes the other too.

2.3

The bonusPossition is analogically the same as the previous two arrays so we will not explain what it does much.
It tracks and takes care of the bonus cordinates and movement.

To have at least 10 methods!

3.1

Main method - the method that is mother of all.
In that method all others are called, and it is the place where the program runs mainly.

3.2

Play method - This method initiates a playing sequence, in other words it starts the game and it is responsible for drawing the board and calling the other methods in the main method.
Play method is also responsible for when the game ends.

3.3

PlayerPosition method - keeps track of the player position: cordinates and movement, also watches for collision.

3.4

Highscores method - prints the highscores from the external file onto the console

3.5

Board methods - you already have heard what it does.

3.6

FallingLines method - makes the obstacles line, holds coordinates, and makes them fall down the board. Just like PlayerPosition.

3.7

BonusPosition method - tracks the position of the bonus, works as the lines or the playerPosition method.

3.8

Options method - the method trough which the board is rescaled on the need of the user.

3.9

ExitConfirm method - a method with which the user should be able to quit the program.

3.10

WriteScores method - when the player dies, this method is responsible for reading the name of the player and adding his score to the highscores file if he is in top10 scores.

3.11

GetHighScores method - Gets all the scores from the external txt file and adds them to the list of scores.

3.12

GetHighScoreNames method - Same as the method above but reads only the names of the players and adds them to another list.

3.13

Level method - changes the speed at which the lines falls according to the current score of the player.

3.14

ResetGame method - when the game is over, this method resets all the positions of lines, bonuses and player, resets the current score of the player and the level.

At least 3 existing .Net Classes!

4.1

System.Threading - used to make the console sleep while in play mode.

4.2

System.IO - used to read and write highscores from/to the external file.

4.3

System.Collections.Generic - Lists are used for the highscores

4.4

System.Text - the whole board is appended to a StringBuilder before being printed on the console

At least 2 exception handlings!

5.1

The first exeption is in case wrong parameters for the player are somehow pressent, then an error occurs that says that you cant make the character go out of the field.

5.2

Second exeption is in the board, in case the parameters for the field does are not set for a proper size of the field, you get an error which tell syou that the size for the border is incorrect for the game.

At least 1 use of external text file!

6

HighScores.txt - used to keep the players' names and scores so that they are kept when the game closes and can be read from inside the game

--------------------------------------------------------------------------------

Work by people:

Y.Maltsiev(Яни Малциев) has taken part in programming the player. - Player cordinates and synchronisation and fixes on it.

toshocorp(Тодор Павлов)'s part was to make the player die on collision. - Player and obstacles synchro mainly.

shunobaka(Веселин Минев) contributed by making the functionality of the menu and the score system .

veselints(Веселин Цветанов) is our team leader which used ways of skillful communication to distributed the roles between the team members, he made the in game feature "bonus", which gives extra points if caught.

Hristiyan_Andreev(Християн Андреев) made the exception handling in the program and cosmetic upgrades.

kabumko(Теодор Архондаки) documentation and scaling difficulty of the game.

yordansg(Йордан Георгиев) has programmed the input and output of the text file for the highscores.

success(Христо Кокалов) helped with programming the game menu and provided the team with useful ideas for the game.