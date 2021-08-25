# Epicodus Team Week Project 02 | Leek Quest

It's Leek Quest! More details pending.

## Useful links and documentation

- Github Repo: https://github.com/AlyxMoon/epicodus-team02-leek-quest
- Trello Board: https://trello.com/b/N4zRdELl/epicodus-team-week-leek-quest
- Postman (contains API route information): https://www.postman.com/dark-spaceship-828513/workspace/epicodus-team-week-02-leek-quest/collection/4966897-a191b6a2-4637-4b6e-853f-ff04e0d067a1

## Setting up for development

There are two pieces to this project, a front-end and back-end component. They run separately so you'll need to set up your environment for each individually.

### Client
Ensure you have the following:
- `npm` or `yarn`
- `node`

1. open a terminal and go to the `client` folder
2. install dependencies with `npm install` or `yarn`
3. run the dev server with `npm run serve` or `yarn serve`
4. access the dev server at `http://localhost:8080`

### Server
Ensure you have the following:
- `dotnet` (.Net 5.0)
- `mysql` or `docker`

1. Ensure mysql is running
  - alternatively, with Docker, have the Docker daemon running and run `docker compose up -d` from the root folder (this directory)
2. open a terminal and go to the `server` folder
3. run the dev server with `dotnet watch run`
4. access the dev server at `http://localhost:5000`

### Working with client and server

If you have both servers running in separate processes, you can access everything through `http://localhost:5000`. Anything that is not an api route will be passed to the client server.

If you'd like a convenience script for running both dev servers at once, open a terminal in the root folder and run `bash scripts/run-client-and-server.sh`, which will run both servers in the same process.