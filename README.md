# MMOB-Project

GitHub Page: https://chenyfz.github.io/MMOB-Project/

### Preparation
1. Install nodejs and pnpm (https://pnpm.io/)
2. Install dependencies `pnpm install`

### Test locally
1. To test locally, you have to manually build the project and put the output in `this-dir/unity-webgl`. This folder is ignored by git.
2. To run a dev server locally, use `pnpm dev`, follow the instructions in terminal.

### Deploy
Currently, the demo is hosted on GitHub Page, some other works needs to be done to deploy it on our own server.

**All changes in Main branch will trigger deploy, the CI pipeline will cost about 10 minutes (unity compile in GitHub Action takes a lot of time)**
You can track progress here: https://github.com/chenyfz/MMOB-Project/actions

Since you don't have to upload the `unity-webgl` folder and the compilation is done in linux environment,
The output files may not be identical to the local windows compiled version.

### Todo list
- [x] Initialize unity project
- [ ] Test communication between web and unity
  - [ ] unity -> web
  - [ ] web -> unity
- [ ] Use command line to compile unity project (for local preview)
- [ ] Backend
  - [ ] test api
  - [ ] test database
  - [ ] database backup mechanism
- [ ] GitHub Action
  - [x] compile and deploy to a GitHub page
  - [x] use GitHub Action to compile unity
  - [ ] Use docker to combine unity, front-end, backend and database.
- [ ] Deploy to UU student server
  - [ ] Manually deploy
  - [ ] Update auto trigger deploy