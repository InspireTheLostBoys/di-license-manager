import Vue from 'vue'
import VueRouter from 'vue-router'

import Index from '../views/Index.vue'

import CarList from '../views/car/list.vue'
import CarAdd from '../views/car/add.vue'
import CarEdit from '../views/car/edit.vue'

import LicenseList from '../views/license/list.vue'
import LicenseAdd from '../views/license/add.vue'
import LicenseEdit from '../views/license/edit.vue'

import ProductList from '../views/product/list.vue'
import ProductAdd from '../views/product/add.vue'
import ProductEdit from '../views/product/edit.vue'

import SiteList from '../views/site/list.vue'
import SiteAdd from '../views/site/add.vue'
import SiteEdit from '../views/site/edit.vue'

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
  },
  {
    path: '/license',
    name: 'licenses-list',
    component: LicenseList
  },
  {
    path: '/license/add',
    name: 'licenses-add',
    component: LicenseAdd
  },
  {
    path: '/license/edit/:id',
    name: 'Licenses-edit',
    component: LicenseEdit
  },
  {
    path: '/product',
    name: 'products-list',
    component: ProductList
  },
  {
    path: '/product/add',
    name: 'products-add',
    component: ProductAdd
  },
  {
    path: '/product/edit/:id',
    name: 'products-edit',
    component: ProductEdit
  },
  {
    path: '/site',
    name: 'sites-list',
    component: SiteList
  },
  {
    path: '/site/add',
    name: 'sites-add',
    component: SiteAdd
  },
  {
    path: '/site/edit/:id',
    name: 'sites-edit',
    component: SiteEdit
  },
]

const router = new VueRouter({
  routes
})

export default router
