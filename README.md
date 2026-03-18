# Translate-API
C# project using a Google API to solve a real-world problem.

Aims to use the Gtranslate NuGet package to translate
text entered by the user to english or from english 
to a selected language. 

### Instructions: 
```
This project is open-ended, take 2 - 3 days 
of lab and either with a partner or alone, 
develop a c# project that solves a real-world 
problem. Maybe your grandma hates her cooking 
instruction app and wants you to build one, 
or you want to create your own youtube video 
search and categorizer hosted on a local 
server. Whatever it is, be creative and think 
about what design patterns are the best 
approach and *explain why using comments*.
```

### Potential Features:
 - choose language to translate to or from
   - start with just english to spanish
   - eventually use a dropdown?
 - view previous translations?

## Structure:
The structure we chose to use for this project
features no Interface or Repository layer. This
is because this application does not use a 
database, and therefore does not need a layer
to interact with one. 

### Core

The app keeps all logic in the ".Core"
project, specifically in the Service layer. The
".Core" project also includes our Models directory
which includes a Prompt for passing in user input
(text prompt and target language) from the Svelte
front-end. There is also a DTO used for sending 
BACK this information from the API (the user's
text prompt and the translated result). 

### API

This layer of the app includes anything that will
interact with the Svelte front-end. This means
the controller that sends data to a localhost URL
will be accessible for the front-end to access. 
This project serves as the middleman between our 
logic and our application UI.

### Web

The front-end of this application uses Svelte, 
a JavaScript framework, and hey api to gain access
to the API project of our solution. It performs a 
fetch to the url endpoint that the API is sending
data to which exchanges the user's prompt and selected
target language for a translated prompt and the 
original prompt for reference. This data is then 
displayed to the user using stateful variables. 