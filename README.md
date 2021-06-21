# Mars_Rover
A console application about a squad of vehicles moving on a 2D matrix field.
.NET framework 4.7.2 

In default you have 2 rovers but you can change this in settings by pressing 2 in the beginning.
Press 1 to start and give input.

  Input format:
    7 7        # WIDTH AND LENGHT OF PLATEAU  
    2 2 W      # 1. ROVER'S POSITION W:WEST E:EAST N:NORTH S:SOUTH  
    RMRMML     # 1. ROVER'S INSTRUCTIONS L:LEFT R:RIGHT M:MOVE  
    1 2 E      # 2. ROVER'S POSITION W:WEST E:EAST N:NORTH S:SOUTH  
    LLMMRMLM   # 2. ROVER'S INSTRUCTIONS L:LEFT R:RIGHT M:MOVE  
      
Inputs have spaces inbetween except the instructions.  
L and R only effects the direction of the rover. M moves rover 1 step toward its direction.  

Output gives the final position and direction of the rovers.  
  Output format:  
    4 3 N  
    0 3 W  
    
#Mars_Rover Unit tests  

2 Test Method exist inside Unit testing project.  
  1-Read_Instructions_Test()  
  Input(input_value) type is string[] and output types are string.  
  expected_output format for 2 rover is "2 2 N\n4 2 E" rovers' output has "\n" between.  
  
  2-Move_Rover_Test()
  Inputs(input_value) types are char[],int and output types are string.
  
  
 For more tests change the input_value and expected_value as explained format. Run the tests.
  


    
    
    
