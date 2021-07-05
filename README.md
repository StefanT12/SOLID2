 # SOLID principles test/exercise:
A programming exercise that test the understanding of basic principles and patterns

The test should be solved in two rounds, their purpose is to check if the applicant can plan ahead and write extensible code before additional features are known.

The test was modified so as to make it more challenging. Source of the test:

https://github.com/Jinjinov/job-interview-solid-principles-test/tree/f3e93906da129dc2e5939379d31129e08f3631e4

---

Use the programming language of your choice to write an application (it can be a console / terminal application or an application with a GUI).
The code must be modular and easily extensible.
After you complete the first tasks you will receive short additional tasks to test if the code is really easily extensible.

Round 1:

1. Design a ferry terminal. Two kinds of ferries are available at any time:
   - small ferry has space for 8 small vehicles (cars pay 3€ / vans pay 4€)
   - large ferry has space for 6 large vehicles (buses pay 5€ / trucks pay 6€)

   The application must display all income made from tickets.
2. Vehicles are constantly arriving to the terminal in random order.
   A terminal employee is paid to park them on the ferry - his salary is 10% of every ferry ticket.
   The application must display his income.
3. Every vehicle arrives with a random amount of gas.
   If any vehicle has less than 10% of gas left, the terminal employee must fill it up at the gas station.
   The application must display the amount of gas for the current vehicle.
4. Every van and every truck must go through customs inspection.
   The terminal employee must open the cargo doors for inspection.
   The application must display whether the cargo doors of the current vehicle are open or closed.
5. Track the car from the arrival to the ferry.
   The application must display the name of the last location visited (crossroads don't count).
   
   
   
            A
            |
        G - 1 - S
        |   |
        C - 2 - L

        A - Arrival
        G - Gas station
        1 - crossroad 1
        S - Small ferry
        C - Customs inspection
        2 - crossroad 2
        L - Large ferry
        
   
6. Rotate all employees so that an employee does not get one job after the other.
7. Store all vehicles parked in the ferry.
8. Once a ferry is full, it leaves the Terminal and a new one takes its place.


Round 2:

1. Add another terminal employee that does the exact same job.
   His salary is 11% of every ferry ticket.
   The application must display his income.
2. Add a battery recharge station.
   Every electric car arrives with a random battery charge.
   If the battery is below 10% then the terminal employee must recharge it.
   The application must display the battery charge for the current vehicle.
3. Add a new eco ferry that carries 10 eco cars (electric cars pay 1€ / hybrid cars pay 2€).
   Hybrid cars don't have to be refilled with gas if they have more than 50% battery charge.
   Hybrid cars don't have to have the battery recharged if they have more than 50% of gas left.

            A
            |
        G - 1 - S
        |   |
        C - 2 - L
        |   |
        B - 3 - E

        A - Arrival
        G - Gas station
        1 - crossroad 1
        S - Small ferry
        C - Customs inspection
        2 - crossroad 2
        L - Large ferry
        B - Battery recharge station
        3 - crossroad 3
        E - Eco ferry

---

# Solution:

I have used the single responsibility principle when modelling classes to give them a simple purpose, like so:

Terminal - processes vehicle from arrival to embarking
RegularLocation - prepares the vehicle for embarking
EmbarkLocation - embarks the vehicle
Ferry - stores ferry data & methods to manipulate it
.
.
.
etc

This has the advantage of having a readable architecture and keep the efforts small but focused (one class/purpose at a time).

---

The interface segregation, substitution & polymorphism kept the architecture easily extendable and modular. 

Example: 

Method RunOperations in ILocation requires an IVehicle but, in a class extending it - such as GasStation- more functionality is needed - such as Refuel and FuelLevel -. Other locations however (like RechargeStation location for electric vehicles), may not need that type of functionality. Instead of making a bigger interface, clutter location logic, and expose all sort of functionality to the wrong locations, I have chosen to:
1. Make smaller interfaces, each dealing with one aspect of the vehicle (IGasVehicle, ICargoVehicle, IElectricVehicle).
2. Implement their functionality at a class level 
	(CargoVehicle inherits from GasVehicle - which implements IGasVehicle and IVehicle - and implements ICargoVehicle).
	(HybridVehicle implements IGasVehicle, IVehicle, IElectricVehicle)
3. Pass the entities created with that class constructor as an interface (I pass CargoVehicle as IVehicle in ILocation.RunOperations method).
Example of what this does:

A Truck then becomes a CargoVehicle inheriting from GasVehicle and extending IVehicle, IGasVehicle, ICargoVehicle. The GasStation can then cast it from IVehicle as IGasVehicle and use it as its needed, while the RechargeStation will not execute anything with it because it cannot be substituted for IElectricVehicle.

This way, many other types of operations and vehicles can be added without any major architectural changes.

---
Logging:

The project needed a logging proccess to document each operation applied to the vehicle in each location available. The class Result contains an IList<string> (for logs) that all locations are forced to return to the terminal. Once the terminal finishes with all locations, it then passes a log made out of compiled Results which is then printed in Program.cs.

 
This approach separates the Terminal from being dependent on a console app but as well separates concerns (in my opinion, it is not the Terminal's concern to print messages in the console).

Errors/Conflicting cases, method returns:

Handled in most cases by a class Result, which has an enum for result codes. Locations generate Result instances based on what is happening inside them. In this scenario, Terminal then decides how to interpret the results appropriately

Essentially, the class Result is used for both logging and conflicting cases (if any).

---
Factory Pattern:

Hides the implementation and random generation of vehicles. Everything that was needed in this exercie was a method that returns a randomly generated vehicle in the form of IVehicle, that is then passed to the Terminal and its Locations.

---

Testing

Before creating the random generation / simulation, I had to test vehicles passing through the terminal I have done so with the Tests class. Its static nature makes it easy to call and the specificity & size of each test inside (one specific vehicle ran one time through the Terminal) proved to be instrumental when debugging and creating new features.

---

Refactoring

10 iterations of refactoring. With each new one, a cleaner version of the project was achieved.

E.g: Inside VehicleFactory, instead of the switch, I used delegates and templates stored in dictionaries with enums as keys to create instances of random vehicles (one can imagine the errors this practice is prone to).

---

Future Improvements

-Use generics or find patterns for VehicleFactory (values are hardcoded inside logic - not a good practice)
	
-Refactor Results - it initializes with a List every time is needed (perfomance consuming)
	
-Refactor FlagBasedLocation - it is useless, I only have one location type that uses it (Embarklocation). Vital code can be migrated there.

-Clean namespaces / make namespaces

---

Overall, the exercise was solved for in a manner that is easily extendable if other features are needed. 



