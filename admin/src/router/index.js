import Vue from 'vue'
import VueRouter from 'vue-router'

import Index from '../views/Index.vue'

import CarList from '../views/car/list.vue'
import CarAdd from '../views/car/add.vue'
import CarEdit from '../views/car/edit.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'index',
    component: Index
  },
  {
    path: '/car',
    name: 'cars-list',
    component: CarList
  },
  {
    path: '/car/add',
    name: 'cars-add',
    component: CarAdd
  },
  {
    path: '/car/edit/:id',
    name: 'cars-edit',
    component: CarEdit
  }
]

const router = new VueRouter({
  routes
})

export default router
