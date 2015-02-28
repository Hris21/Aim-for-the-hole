# Aim-for-the-hole
We are the best.

Documentation date update 27/02/2015

This is the documentation for the game Aim For The Hole - chosen by consensus between the programmers and the leader.
The project main idea and task is, a game to be made from different people working as a team.
In this program the following people have taken part: 
Y.Maltsiev(Яни Малцев), shunobaka(Веселин Минев), veselints(Веселин Цветанов), yordansg(Йордан Георгиев), kabumko(Теодор Архондаки), success(Христо Кокалов), toshocorp(Тодор Павлов), Hristiyan_Andre(Християн Андреев).

--------------------------------------------------------------------------------

Generral rules for the game are:

To have 1 or more multy-dimensional arrays!

1

We have 1 multy-dimensional char array called board, which is used to visualize our play-field border.
The board stars as a field of 8 by 8.
The array is used in the Border method which sets the char value to a symbol that represents the field.
The Border method also sets the first initiation of the line that is supposed to kill the hero, and the heros position. 

To have 3 or more one-dimensional arrays!

2.1

We have size array which sets the size for the border array, it is used in setting starting value of players and bonus position.
Trough the starting menu it can be set to different values, if the game is started the values that are now present in the array are used to shape the play field.
That array is mostly used to set a limit to where the objects should be and where not!!!
It is used in the Options method to set size for the border as we said before, and to rescale the console so the program works correctly.

2.2

The playerPossition array is the the one that saves the values of that where the player is located on the board.
It is used to set the board trough the Board method, and in the PlayerPosition method.
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

Highscores method saves the score of the game and prints the result

3.5

Board methos - you already have heard what it does.

3.6

FallingLines method - makes the obstacles line, holds coordinates, and makes them go down the board. Just like PlayerPosition.

3.7

BonusPosition method - tracks the position of the bonus, works as the lines or the playerPosition method.

3.8

Options method - the method trough which the board is rescaled on the need of the user.

3.9

ExitConfirm method - a method with which the user should be able to quit the program.

3.10 - pending right now...

At least 3 existing .Net Classes!

4.1

Class 1

4.2

Class 2

4.3

Class 3

At least 2 exception handlings!

5.1

First exeption!!!

5.2

Second exeption!!!

At least 1 use of external text file!

6

Text file

--------------------------------------------------------------------------------

Work by people:

Y.Maltsiev(Яни Малциев) has taken part in programming the player. - Player cordinates and synchronisation and fixes on it.

toshocorp(Тодор Павлов)'s part was to make the player die on collision. - Player and obstacles synchro mainly.

