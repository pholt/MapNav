# MapNav
Coding exercise.

Setup steps:

1) Put on web server. 
2) Run it. 
3) Hit the /api/GetMapNav with a GET request passing in a JSON string.

This JSON string should include a single property called "data" and a data string of comma separated "instructions".
Instructions should start with either the character 'L' or 'R' then have an integer.

Example JSON string input:
"{\"data\": \"L3, R2, L5, R1, L1, L2\"}"

Output is a JSON object with an integer in the "data" property describing distance from a central point.

Example JSON string output:
"{\"data\": \"10\"}"
