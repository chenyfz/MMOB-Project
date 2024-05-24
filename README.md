# MMOB-Project

GitHub Page: https://chenyfz.github.io/MMOB-Project/

### Preparation
1. Install nodejs (> v20) and pnpm (https://pnpm.io/)
2. Install dependencies: `pnpm install`

### Test locally
note: the point 2 is added due to this issue: https://github.com/vitejs/vite/issues/16648

1. To test locally, you have to manually build the project and put the output in `./public/unity-webgl`. You may need to create this folder for the first time because it is ignored by git. The file names should all start with "unity-webgl" (e.g., `unity-webgl.data`).
2. use `pnpm test` to preview and test the game part (port: 4173, browser reload needed to update).
3. use `pnpm dev` to test the rest of the webpage (HMR).

### Deploy
Currently, the demo is hosted on GitHub Pages, some other works needs to be done to deploy it on our own server.

**All changes in main branch will trigger deploy. The CI pipeline will cost about 10 minutes (mainly compiling unity...).**
You can track progress here: https://github.com/chenyfz/MMOB-Project/actions

The `./public/unity-webgl` folder should not be uploaded, GitHub Action will do the compile work.
Since the compilation is done in a linux environment, the output files may not be identical to the local windows compiled version.

If the GitHub Page goes wrong, it is probably something wrong with GitHub Action.

If the GitHub Page is not up-to-date in your phone, try to use private mode of your browser (so that there is no cache)

### Todo list
- [x] Initialize unity project
- [x] Test communication between web and unity
  - [x] unity -> web
  - [x] web -> unity
- [x] Web page basic framework
- [ ] Backend
  - [ ] test api
  - [ ] test database
  - [ ] database backup mechanism
- [x] GitHub Action
  - [x] compile and deploy to a GitHub page
  - [x] use GitHub Action to compile unity
- [ ] Deploy to UU student server
  - [ ] Use docker to combine unity, front-end, backend and database.
  - [ ] Manually deploy
  - [ ] Update auto trigger deploy