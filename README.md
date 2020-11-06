# MapNav
Coding exercise.

This as a .NET WebAPI project with a nested Angular SPA routed in as the only view using .NET's MVC framework. In a real world scenario, this is an unlikely set up but allows for ease of use when opening the solution and running it on IIS Express. Ideally, the WebAPI project would be build and served separately, but I felt that a one-click setup was better in this particular case.

# Setup steps:

1) Open the solution file in Visual Studio.
2) Run with IIS Express and any modern browser.
3) Input your instructions into the form and hit the "Calculate!" button.

The input string is converted to a JSON string with single property called "data" and a data string of comma separated "instructions".
Instructions should start with either the character 'L' or 'R' then be followed by an integer (e.g. "L23" or "R3").

Example JSON string input:
"{\"data\": \"L3, R2, L5, R1, L1, L2\"}"

Output is a JSON object with an integer in the "data" property describing distance from a central point.

Example JSON string output:
"{\"data\": \"10\"}"

This JSON is read by the client which pulls out the data value and displays it.
