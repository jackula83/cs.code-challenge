# cs.code-challenge

## Description

An application that assigns sales people to customers, based on spoken language and the specialty area.

## Challenges

- Provided data `salesperson.json` collates language and specialty information together.
- Rule-set [here](https://github.com/farajfarook/code-challenge) is inconsistent, particularly the `Tradie Vehicle` specialty.
- Requirement for `No-storing data` puts emphasis of data modelling and management in the application layer.
- Allowed time for coding is 2 days at best in between work, parenting and chores. However can still rough out the design in my head at other times.
- Preference for AngularJS for the frontend, instead I will be using React. I can learn Angular but I can't do it within 2 days **and** finish the code.

## Scope & Progress:

This section tracks the scope and progress made to the code challenge.

### Pre-coding

- [x] Concept & Design: Design the **optimal** solution given the time limit, not the **perfect** solution.

### Day 1 coding

- [x] Develop Backend + Unit Tests (31-Oct-20)

### Day 2 coding

- [x] Develop Frontend (01-Nov-20)
- [x] Build development pipeline (01-Nov-20)
  - [x] Nginx server (frontend)
  - [x] Nginx server (main)
  - [x] Dockerfiles (development)
  - [x] Docker-Compose
- [ ] Build production pipeline
  - [ ] Dockerfiles (production)
  - [ ] Travis integration

### Spare time (or post delivery)

- [ ] Bonus: AWS Task Definition
- [ ] Bonus: AWS Deployment
- [ ] Bonus: CNAME redirect from my website
- [ ] Bonus: Add technical documentation
- [ ] Bonus: Unit tests for frontend
- [ ] Bonus: Additional code refactoring

## Manual

Quick start guide for the application.

### Development Pipeline

This section demonstrates how to run the app in development mode.

#### Starting up

Run:

```
docker-compose up --build
```

_(Remove `--build` on subsequent runs)_

Then open a web browser and go to:

```
http://localhost:4005/
```

_(You can change the port number from [docker-compose.yml](https://github.com/jackula83/cs.code-challenge/blob/main/docker-compose.yml))_

The development pipeline will run tests and start the `DEBUG` build of the application.
