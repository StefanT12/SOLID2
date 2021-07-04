 # SOLID principles test/exercise:
A programming job interview questions that test the understanding of basic principles and patterns

The test should be solved in two rounds, their purpose is to check if the applicant can plan ahead and write extensible code before additional features are known.

The test was modified so as to make it more challenging.

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

# Solution:

By adhering to the single responsibility principle, each class should do one thing only, E.G

Main classes
1. Terminal - processes Vehicle
2. Employees - holds employee data & functions to change it
3. RegularLocation - prepares vehicle for embarking (there are multiple such locations such as GasStation or ArrivalLocation)        
4. EmbarkLocation - embarks the vehicles (there multiple embark locations for multiple types of vehicles)
5. Dock - holds the ferry & methods to change it with another ferry 
6. Ferry - holds the ferry data (places occupied/free) & methods to change it   
  
Miscellaneous
1. FerryTrafficSimulation - simulates the ferry trafic (when one ferry is full, it will be replaced with an empty randomly generated one)
2. FerryRandNameGen - generates a random name for ferries  
      
RegularLocations:
1. ArrivalLocation - processes the payment for embarking
2. GasStation - refuels gas based vehicles
3. RechargeLocation - recharges electric based vehicles
4. CustomsLocation - inspects the vehicles that have cargo (Van, Truck)
