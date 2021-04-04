Event Manager (Web)
Functional requirements

A client needs to create a web application for managing events and lists of guests invited to these events. 

Each event has a name (required), a type (possible values: conference, seminar, or hackathon), the date it happens (must be in the future when the event is added into the system), and a location name where the event takes place. An event may have a limit to the number of guests who can attend it. The system should track a name, an email address, and the optional textual comment for each of the guests attending a given event. 

The web application should include the following pages:

	1. Event list -- displays a list of current events, including event details,
	the number of registered guests, and the maximum allowed guest count (if any). 
	From that page, it should also be possible to:
		
		- Add a new event (using a form);
		
		- Archive event (removes an event from the list, but keeps it in the system);
	
	2. Manage guests. Guest list -- displays a list of guests attending the selected event. 
	The page should also include brief information about a current event in the header section 
	(event details, current, the maximum, and the remaining number of guests). A user should be able to:
		
		- Import guests (accepts a CSV file, merges new records with the existing list matching data by email field; 
		if the event capacity is exceeded after the import, the application should alert the user about it and do not perform any import);
		
		- Export guests (downloads a CSV file with guest details).
