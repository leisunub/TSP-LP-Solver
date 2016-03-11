# TSP-LP-Solver
TSP LP Solver is a program to build linear programming models for the traveling salesman problem and solve it based on CPLEX and C#.NET.
See the paper "A Small-Order-Polynomial-Sized Linear Program for Solving the Traveling Salesman Problem" by M. Diaby, M.H. Karwan and L. Sun, 2016.
TSP LP Solver is distributed under the Eclipse License v 1.0 (See LICENSE).

*--------------------------  Installation  ----------------------------------*

\Debug\TSPsolvers.exe

*----------------- Third-party software dependencies -----------------*

TSP LP Solver is written in C# with .NET framework 4 and calls CPLEX 12.5 to solve models. IBM ILOG CPLEX Optimization Studio 12.5 is optional.

For those with CPLEX 12.5, all functions in this program are available.

For those with different versions of CPLEX, problems may happen when calling CPLEX to solve (e.g. 'Unable to load DLL cplex125'). If so, users need to adjust references in the source code to rebuild the program.

Users who do not wish to use CPLEX or to modify the source code can choose the Model Only button in order to build a .lp file (no requirement to use CPLEX) which they can then solve using the software of their choice.

*-----------------------  Project Maintainer  -------------------------------*

Dr. Lei Sun
leisun@buffalo.edu
Praxair Inc.
 
*------------------------  Project Web Page  --------------------------------*



*-------------  Bug Reports / Support / Feature Request  --------------------*
See web page or email leisun@buffalo.edu


*----------------------  TSP LP Solver  ------------------------------*

TSP LP Solver builds linear programming (LP) models for the traveling salesman problem and calls CPLEX to solve them as LPs. The interface has been designed to run multiple replications of the chosen problem and run control settings at a time. With this tool, users can: (1) randomly generate or read a TSP cost matrix in multiple ways; (2) directly solve the TSP or only build the LP models; (3) adjust CPLEX settings for different tests; (4) show solutions (optimal objective, variables, routes) in different formats. The MTZ model is available for the purposes of verifying the correctness of the solutions obtained using our LP model. It is solved as an Integer Program, and only its objective function value is displayed.

*------------------- How our software works ----------------------*

See instructions in INSTALL for the interface and functions.
