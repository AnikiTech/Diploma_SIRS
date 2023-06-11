import Vue from 'vue'
import VueRouter from 'vue-router'
import EmptyContainer from '../components/Home/EmptyContainer'
import store from '../store'
import goTo from 'vuetify/es5/services/goto'

Vue.use(VueRouter);


const routes = [
  {
    path: '*',
    name: 'Not-found',
    component: () => import('../components/General/NotFound')
  },
  {
    path: '/', redirect: {name: 'Home'},
    meta: { requiresAuth: true },
  },
  {
    path: '/login',
    name: "Login",
    component: () => import('../views/Login'),
    meta: {requiresLogout: true}
  },
  {
    path: '/home',
    name: "Home",
    component: EmptyContainer,
    meta: { requiresAuth: true }
  },
  {
    path: '/exercises',
    name: "Exercises",
    component: () => import('../components/Home/Exercises'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/colors',
    name: "Memory",
    component: () => import('../components/Exercises/Colors/MemoryColor'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/orderWords',
    name: "WordsMenu",
    component: () => import('../components/Exercises/OrderWord/WordsMenu'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/orderWords/diagnostic',
    name: "OrderWordDiagnostic",
    component: () => import('../components/Exercises/OrderWord/OrderWordDiagnostic'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/orderWords/training',
    name: "OrderWordTraining",
    component: () => import('../components/Exercises/OrderWord/OrderWordTraining')
  },
  {
    path: '/memory/orderWords/statistic',
    name: "WordsStatistic",
    component: () => import('../components/Exercises/OrderWord/Statistic'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/fastReading',
    name: "FastReading",
    component: () => import('../components/Exercises/ReadingFaste/ReadingFast'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/faces',
    name: "Faces",
    component: () => import('../components/Exercises/Faces/Faces'),
    meta: { requiresAuth: true}
  },
  {
    path: '/memory/faces/topicVar',
    name: "TopicVar",
    component: () => import('../components/Exercises/Faces/TopicVar'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/faces/levels',
    name: "Levels",
    component: () => import('../components/Exercises/Faces/Levels'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/faces/training',
    name: "Training",
    component: () => import('../components/Exercises/Faces/Training'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/faces/name',
    name: "Name",
    component: () => import('../components/Exercises/Faces/Name/Name'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/faces/name/exercise',
    name: "NameImg",
    component: () => import('../components/Exercises/Faces/Name/NameImg'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/faces/name-np',
    name: "NameNP",
    component: () => import('../components/Exercises/Faces/NamePatrn/ExNP'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/faces/name-np/exercise',
    name: "NameP",
    component: () => import('../components/Exercises/Faces/NamePatrn/NameP'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/faces/full-name',
    name: "FullName",
    component: () => import('../components/Exercises/Faces/FullName/ExFullN'),
    meta: { requiresAuth: true }
  },
  {
    path: '/memory/faces/full-name/exercise',
    name: "FullNameEx",
    component: () => import('../components/Exercises/Faces/FullName/FullName'),
    meta: { requiresAuth: true }
  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../components/Home/About.vue'),
    meta: { requiresAuth: true }
  },
  {
    path: '/settings',
    name: 'Settings',
    component: () => import('../components/Home/Settings'),
    meta: { requiresAuth: true }
  }
];

const router = new VueRouter({
  mode: "history",
  routes,
  scrollBehavior: (to, from, savedPosition) => {
    let scrollTo = 0

    if (to.hash) {
      scrollTo = to.hash
    } else if (savedPosition) {
      scrollTo = savedPosition.y
    }

    return goTo(scrollTo)
  }
});

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresLogout)) {
    // этот путь будет показан только неавторизованому пользователю
    if (store.getters.isAuth) {
      next({name: 'Home'})
    }
  }
  if (to.matched.some(record => record.meta.requiresAuth)) {
    // этот путь требует авторизации, проверяем залогинен ли
    // пользователь, и если нет, перенаправляем на страницу логина
    if (!store.getters.isAuth) {
      next({
        name: 'Login'
      })
    } else {
      next()
    }
  } else {
    next() // всегда так или иначе нужно вызвать next()!
  }
});


export default router