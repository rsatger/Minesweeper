
- send ssh client details
- nunit quickstart http://www.nunit.org/index.php?p=quickStart&r=2.6.4


- install NuGet Extension
- install Nunit Extension
- add Nunit3 Ref to project (via NuGet)
- Create Test class
- write Test(s) on ReadInput



From: Bertrand Decoux 
Sent: Friday, January 08, 2016 4:50 PM
To: Remy Satger
Subject: RE: pair p.

--//step 1
--create object Cell (Cell Type, + nb mines autour, + all needed flags)
--create enum 
--reveal soit un method d Cell

//step 2
-	Check logic (MinesAround)
-	Fix GameOver
-	PropagateVisibility
-	handle input for wrong value (ask again - don't crash)
-	                * type (number)
-	                * boundries
-	                * extract mechanism (don't write twice)

// next steps
- make the grid size a parameter <100
- randomize des mine position = a <=10% du nombre de cells
- ensure GameOver is Caught early during recursive Reveal 
 - any diff mechanism for GameOver
- tests


Thanks, Bertrand

From: Bertrand Decoux 
Sent: Tuesday, December 29, 2015 15:39 PM
To: Remy Satger
Subject: pair p.

//step 1
create object Cell (Cell Type, + nb mines autour, + all needed flags)
create enum 
reveal soit un method d Cell

//step 2
- make the grid size a parameter <100
- randomize des mine position = a <=10% du nombre de cells
- gitignore
- CellsRevealed as Property with private SET accessor
- handle input for wrong value (ask again - don't crash)
                * type (number)
                * boundries
                * extract mechanism (don't write twice)
- ensure GameOver is Caught early during recursive Reveal 

//step 3: any diff mechanism for GameOver

