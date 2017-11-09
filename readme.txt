To run the program please do the following:

1. Open cmd and find the path to the .exe file as below:
   \nameSort\nameSort\bin\Release\netcoreapp2.0\win10-x64\nameSort.exe 
2. To run the program: nameSort.exe 
3. You can either put in a txt file or enter directly in to the console a list of names/words.  Press ENTER in the console if more information is required.
	3a. Make sure the txt file is in working dir if using a text file
4. The sorted-names-list.txt will save to the same dir

Additional notes:

1. Code can be seen in \nameSort\nameSort\Program.cs
2. Unit testing code can be seen in \nameSort\nameSortTest\UnitTest1.cs
	a. Refer to email on submission for more notes on unit testing

***UPDATES/CHANGES TO PROGRAM + SOLID explanations (in depth when appropriate)***

1. Removed all static classes - following the SOLID 'O' property, if classes requires the state to be changed in the future because if you need to change it after you've made it, all the code has to change too.  When we want to be programmer friendly to each other we don't want to be constantly changing little stuff all the time - hence, no statics.
2. Added an interface for sorting classes- following the SOLID 'S' responsibility, separating into interfaces which group classes together mean that classes only have one responsibility.  Also following the SOLID 'L' principle, interfaces allow us to exhibit polymorphic behaviour - when you access classes through an interface, you can ignore their runtime and treat them interchangably - meaning as per the 'L' principle, objects in a program are able to be replacable with instances of their subtype and correctness would not be altered. This also follows the SOLID 'I' principle, where we have several interfaces and classes split up instead of one general purpose interface where code is hard to find and can get messy and lost within each other.  Interfaces also present us with the 'D' principle, which means when we call in our main methods we reply on the abstractions from the classes in ther interfaces and not set methods (again, no statics also helps with this).  Interfaces means that we can change things in code without having to comb through a giant bit of code and change every little part with it as well.
3. Added a sort by descending and sort by ascending method instead of just one
4. You can now either a txt file or input a list straight in to the args.

Additional notes (about program):

Assumptions
IF using a txt file of names:
1. A name can be anything, including symbols and numbers
2. A person is only permitted one last name, thus in which case a name with e.g. 5 names MUST mean 4 first names and 1 last name