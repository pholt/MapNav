# MapNav
Coding exercise for http://itrellisrecruiting.azurewebsites.net/

This as a .NET WebAPI project with a nested Angular SPA routed in as the only view using .NET's MVC framework. In a real world scenario, this is an unlikely setup... but this allows for ease of use when opening the solution and running it on IIS Express (one button!). Ideally, the WebAPI project would be built and served separately, but I felt that a one-click setup was better in this particular case. I do NOT recommend this approach!

# Setup steps:

1) Open the solution file in Visual Studio.
2) Use the "Start Debugging" feature in VS to launch IIS Express (keyboard shortcut: F5); this should open a browser window automatically.
3) Once on the home page, input your instructions into the form and hit the "Calculate!" button.

Note: if you opened an html file in VS, it might try to route you directly there (which won't work), just trim everything after the port number in the URL.

The input string is converted to a JSON string with single property called "data" and a data string of comma separated "instructions".
Instructions should start with either the character 'L' or 'R' then be followed by an integer (e.g. "L23" or "R3").

# Brief API Details

The single API endpoint is located at /api/MapNav
It accepts a POST of JSON data and is expecting the actual value to be accessed from a property called "data".

Example JSON string input:
"{\"data\": \"L3, R2, L5, R1, L1, L2\"}"

Output is a JSON object with an integer in the "data" property describing distance from a central point.

Example JSON string output:
"{\"data\": \"10\"}"

Known issues:
* Negative numbers work, though you can't get a negative output
* No form validation or error handling on the front end
* Large integers were not tested, we are at the mercy of int.Parse()
