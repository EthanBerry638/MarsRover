# Mars Rover
A robust C# console application that simulates navigating a robotic rover across a plateau on Mars.

## 🚀 Key Features
Movement Engine: Logic for rotation and forward movement with wrap-around direction handling.

Defensive Boundary Logic: Integrated collision detection prevents rovers from moving outside the plateau coordinates.

Input Parsing: Parsers handle raw string inputs, filtering out invalid characters and ensuring data integrity.

User-Friendly CLI: A UI orchestrator logic to provide a seamless user experience.

Unit Tested: Over 60 NUnit tests covering movement, rotation, parsing, and boundary edge cases.

## 🛠 Tech Stack
Language: C# 11 / .NET 8.

Testing: NUnit

## 📖 How to Run
Open MarsRover.sln in Visual Studio.

Ensure MarsRover.Console is set as the startup project.

Press F5 to run.

Follow the prompts to set the plateau size (e.g., 5 5), initial rover position (e.g., 1 2 N), and movement instructions (e.g., LMLMLMLMM).

You should get: "Rover moved to X: 1, Y: 3. It is now facing: N." in the terminal.

Enjoy!

## 🛣️ Roadmap 
Collision Output: Telling the user where and when they collided as it happens.

Multiple Rovers: Including collision detection between rovers.

Obstacles: Immovable objects that the rover would collide with.

Live Map: A visual representation of the plateau and the rovers moving on it in the console.