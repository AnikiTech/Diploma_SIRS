import Vue from 'vue'
import VueRouter from 'vue-router'
//import Home from '../views/Home.vue'

import AppHeader from '../components/AppHeader'

import Topic2 from '../components/Topic2/Name/Topic2'
import Face from '../components/Topic2/Face'
import Training from '../components/Topic2/Training'
import TopicImg from '../components/Topic2/Name/TopicImg'
import NameP from '../components/Topic2/NamePatrn/NameP'
import ExNP from '../components/Topic2/NamePatrn/ExNP'
import FullName from '../components/Topic2/FullName/FullName'
import ExFullN from '../components/Topic2/FullName/ExFullN'
import TopicVar from '../components/Topic2/TopicVar'
import Level from '../components/Topic2/Level'

import Topic1 from '../components/Topic1/Topic1'
import TopicWord from '../components/Topic1/TopicWord'

import Layout from '../components/draft/Layout'
import NotFound from '../components/draft/NotFound'

import Settings from '../settings/Settings'

Vue.use(VueRouter);

export default new VueRouter({
  mode: 'history',
  routes: [
    {
      path: '*',
      name: 'Not-found',
      component: NotFound
    },
    {
    path: '/',
    component: AppHeader
    },
    {
      path: '/settings',
      name:'settings',
      component: Settings
      },
    {
      path: '/topicVar',
      name:'difficulty-level',
      component: Layout,
      children: [
        {
          path: '',
          name:'faces-level',
          component: Face
        },
        {
          path: '',
          name:'difficulty-level',
          component: TopicVar
        },
        {
          path: '',
          name:'training',
          component: Training
        },
        {
          path: '',
          name:'level',
          component: Level
        },
        {
          path: 'topic1',
          name:'name',
          component: Topic2
        },
        {
          path: 'topic2',
          name:'exerciseNP',
          component: ExNP
        },
        {
          path: 'topic3',
          name:'exerciseFull',
          component: ExFullN
        },
        {
          path: 'topic1/topicImg',
          name:'task2',
          component: TopicImg
        },
        {
          path: 'topic2/nameP',
          name:'nameP',
          component: NameP
        },
        {
          path: 'topic3/full',
          name:'fullname',
          component: FullName
        }
      ]
    },
    {
      path: '/topic1',
      name:'instruction',
      component: Layout,
      children: [
        {
          path: '',
          name:'instruction',
          component: Topic1
        },
        {
          path: 'topicWord',
          name:'words',
          component: TopicWord
        }
      ]
    },
]
})
