# Battleship

# General Specifications

This solution implements the following functionality:

- Creates a Board of size 10 x 10: X axis from 'a' to 'j' and Y axis from 1 to 10.
- Adds Battleships on the board.
- Directs attacks on the board based on user input of coordinates.
- Reports Hit and Misses.
- Reports when Game is finished when there are no more BattleShips on the Board.

# Technical Specifications

This is a .Net Core solution containing two projects:

- A .Net Core Console project: Provides a very basic cli to initialise a game
- A .Net Core XUnit project: Provides some UTs to test some functionality from Ship, Board and Game objects.

# Running this project

- The only requirement to run this project is to have a computer with .Net Core, installed
- When running this project there is some very basic interaction between the application and person running the solution
- The flow of the application when is running is the following
   
   Note: An exhaustive validation for user input has not been implemented in this solution.
   
     1. User should indicate if they are ready to start a game
     
     2. At least one Battleship should be added to the Board once the game has started
         User should indicate when they wish to stop placing Ships on the Board
         Ships are placed on the Board with data based in the following input:
         - A X point for an Origin Coordinate based in a character from 'a' to 'j'
         - A Y point for an Origin Coordinate based in a number value from 1 to 10
         - A number specifying the intended Length of the Ship, i.e. how many Coordinates will the Ship take up on the Board
         - A character specifying the orientation of the Ship, indicating whether the Ship will face North, South, East or West.
           based on the following characters: 'n', 's', 'e' and 'w'
           
     3. The User should direct Attacks on the Board by specifying a Coordinate based in the following input:
         - A X point for an Origin Coordinate based in a character from 'a' to 'j'
         - A Y point for an Origin Coordinate based in a number value from 1 to 10
         
     4. The User will be informed whether their attacks are Hit or Miss
     
     5. The Game will get into an infinite loop until all the Ships on the Board are distroyed.
