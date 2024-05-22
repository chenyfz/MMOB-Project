import { createRouter, createWebHistory } from 'vue-router'
import HomePage from '../pages/home-page.vue'
import GamePage from '../pages/game-page.vue'
import SurveyPage from '../pages/survey-page.vue'


const routes = [
    {
        path: '/',
        name: 'home',
        component: HomePage,
    },
    {
        path: '/game',
        name: 'game',
        component: GamePage,
    },
    {
        path: '/survey',
        name: 'survey',
        component: SurveyPage,
    },

]

const router = createRouter({
    history: createWebHistory(import.meta.env.VITE_BASE_URL),
    routes,
})

export default router
