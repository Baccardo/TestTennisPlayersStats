******* README : How to run and test TennisPlayersStatsWebApi Application *******

- Get the full solution from the Github Repo.
- Open the .sln file to load all projects (2 project, main one named TennisPlayersStatsWebApi and the unit tests project named TennisPlayersStatsWebApi.Tests.
- Compile the solution, you can now launch unit tests to check all of them from the test explorer.
- To run the app, press F5 to run the application : A browser window will open with the default url : http://localhost:60086/api/players
- To test the Get /players endpoint type http://localhost:60086/api/players (the default url already) to show all players sorted Id.
- To test the Get /players/<id> endpoint for an existing player type for example http://localhost:60086/api/players/17 to show the player with Id 17.
- To test the Get /players/<id> endpoint for a player that does not exist type for example http://localhost:60086/api/players/1 to show 404 returned.
- To test the Delete /players/<id> endpoint you can use de the postman project you will find in the App_Data directoryof the unit tests project.
- Postman project contains 5 requests ( GelAllPlayers(Sorted by Id), GetPlayerById(Existing Player), GetPlayerById(Not Existing Player), DeletePlayerById(Existing Player), DeletePlayerById(Not Existing Player) )