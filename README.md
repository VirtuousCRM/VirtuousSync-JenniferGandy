# Virtuous Sync
A console app to call Virtuous, Query Contact information and write it to a csv file

### Instructions
- Fork or clone the repo
- Look for and resolve bug(s)
  - Push a PR to fix the issue(s)
- Implement change to GetContactsAsync to fetch Contacts where State is AZ
  - Push a PR to update the console app with finished feature
- Implement change to save data to a database instead of a CSV file
  - Push a PR to update the console app with finished feature
- IF you have plenty of time at the end, show off and refactor to improve the codebase!
  - Push a PR of the refactor with documentation on why you chose to change something

You can find the API key for the exercise [here](https://keepersecurity.com/vault/share/#ea5rY4otBdLegGVuBPQIcc0ugJWPxHBIXlVQjlLAc2E)


### Refactoring Updates
 - I switched the Group and Condition logic to be strongly typed as that is a core feature of C# and I want the benefits of it when I am querying an external api.
 - I created a Models folder to group all POCOS (plain old C# / Clr / class objects), this is not for functionality but rather to ensure the codebase remains readable as it expands.
 - I added simple try-catch logic to the main methods performing business logic required for the application to function.