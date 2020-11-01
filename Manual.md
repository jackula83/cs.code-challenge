# Manual

This is the quick start manual for the CarSales Resource Finder.

## Main Features

This section will describe the main features of the application. Please see the image below for the main page layout:
![page intro](https://github.com/jackula83/cs.code-challenge/blob/main/ManualAssets/intro.png?raw=true)

This layout works in both desktop and mobile modes, and has a Navigation Bar on top with two features that can be used at any time:

| Feature                                                                                                               | Description                                                                               |
| --------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------- |
| ![new customer](https://github.com/jackula83/cs.code-challenge/blob/main/ManualAssets/intro-newcustomer.png?raw=true) | Simulates a new customer arrival, allowing a new sales specialist to be _assigned_.       |
| ![reset state](https://github.com/jackula83/cs.code-challenge/blob/main/ManualAssets/intro-resetstate.png?raw=true)   | Resets the application state, restoring the original 8 sales specialists as _unassigned_. |

### Workflow

1. To start, click on a language option to select it and move onto the next page. Here _English_ is the _Doesn't Speak Greek_ option.
   ![language selection](https://github.com/jackula83/cs.code-challenge/blob/main/ManualAssets/intro-english.png?raw=true)
   <br />
2. Likewise, on the next page, click on a specialty option to select it and move onto the next page. Here _Other_ is the _Not looking for anything specific_ option.
   ![specialty selection](https://github.com/jackula83/cs.code-challenge/blob/main/ManualAssets/specialty.png?raw=true)
   <br />
3. Finally, a sales person shall be allocated.
   ![sales specialist allocation](https://github.com/jackula83/cs.code-challenge/blob/main/ManualAssets/final.png?raw=true)
   <br />

## Development Pipeline

The development pipeline will run tests and start the `DEBUG` build of the application.

### Starting up

Run:

```
docker-compose up --build
```

You can remove `--build` on subsequent runs.

Then open a web browser and go to:

```
http://localhost:4005/
```

You can change the port number from [docker-compose.yml](https://github.com/jackula83/cs.code-challenge/blob/main/docker-compose.yml)
