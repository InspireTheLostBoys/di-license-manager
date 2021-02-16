import Vue from 'vue'
import VueRouter from 'vue-router'

import Index from '../views/Index.vue'
import noe_customer from '../views/license-wizard/noe-customer.vue'
import customer_select from '../views/customer/select.vue'

import AddProduct from '../views/nesting/addProduct.vue'
import toSelectProduct from '../views/nesting/toSelectProduct.vue'


import CarList from '../views/car/list.vue'
import CarAdd from '../views/car/add.vue'
import CarEdit from '../views/car/edit.vue'


import AdminUserList from '../views/adminUser/list'
import AdminUserAdd from '../views/adminUser/add.vue'
import AdminUserEdit from '../views/adminUser/edit.vue'


import CustomerList from '../views/customer/list'
import CustomerAdd from '../views/customer/add.vue'
import CustomerEdit from '../views/customer/edit.vue'


import EmailSettingsList from '../views/emailSettings/list'
import EmailSettingsAdd from '../views/emailSettings/add.vue'
import EmailSettingsEdit from '../views/emailSettings/edit.vue'


import LicenseList from '../views/license/list'
import LicenseAdd from '../views/license/add.vue'
import LicenseEdit from '../views/license/edit.vue'

import ProductList from '../views/product/list'
import ProductAdd from '../views/product/add.vue'
import ProductEdit from '../views/product/edit.vue'


import RecipientList from '../views/recipient/list'
import RecipientAdd from '../views/recipient/add.vue'
import RecipientEdit from '../views/recipient/edit.vue'


import SiteList from '../views/site/list'
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
    path: '/new-or-existing-customer',
    name: 'noe_customer',
    component: noe_customer
  },
  {
    path: '/customer-select',
    name: 'customer-select',
    component: customer_select
  },
  {
    path: '/add-product',
    name: 'add-product',
    component: AddProduct
  },
  {
    path: '/to-select-product',
    name: 'to-select-product',
    component: toSelectProduct
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

  /////////////////////////////////

  {
    path: '/adminUser',
    name: 'adminUsers-list',
    component: AdminUserList
  },
  {
    path: '/adminUser/add',
    name: 'adminUsers-add',
    component: AdminUserAdd
  },
  {
    path: '/adminUser/edit/:id',
    name: 'adminUsers-edit',
    component: AdminUserEdit
  },

  /////////////////////////////////

  {
    path: '/customer',
    name: 'customers-list',
    component: CustomerList
  },
  {
    path: '/customer/add',
    name: 'customers-add',
    component: CustomerAdd
  },
  {
    path: '/customer/edit/:id',
    name: 'customers-edit',
    component: CustomerEdit
  },

  //////////////////////////////////

  {
    path: '/email',
    name: 'emailSettings-list',
    component: EmailSettingsList
  },
  {
    path: '/email/add',
    name: 'email-add',
    component: EmailSettingsAdd
  },
  {
    path: '/email/edit/:id',
    name: 'email-edit',
    component: EmailSettingsEdit
  },

  ////////////////////////////////////

  {
    path: '/license',
    name: 'license-list',
    component: LicenseList
  },
  {
    path: '/license/add',
    name: 'license-add',
    component: LicenseAdd
  },
  {
    path: '/license/edit/:id',
    name: 'license-edit',
    component: LicenseEdit
  },
 ////////////////////////////////////
  {
    path: '/product',
    name: 'product-list',
    component: ProductList
  },
  {
    path: '/product/add',
    name: 'product-add',
    component: ProductAdd
  },
  {
    path: '/product/edit/:id',
    name: 'product-edit',
    component: ProductEdit
  },
  ////////////////////////////////////
  {
    path: '/site',
    name: 'site-list',
    component: SiteList
  },
  {
    path: '/site/add',
    name: 'site-add',
    component: SiteAdd
  },
  {
    path: '/site/edit/:id',
    name: 'site-edit',
    component: SiteEdit
  },

  /////////////////////////////////

  {
    path: '/site',
    name: 'site-list',
    component: SiteList
  },
  {
    path: '/site/add',
    name: 'site-add',
    component: SiteAdd
  },
  {
    path: '/site/edit/:id',
    name: 'site-edit',
    component: SiteEdit
  },

  /////////////////////////////////

  {
    path: '/product',
    name: 'product-list',
    component: ProductList
  },
  {
    path: '/product/add',
    name: 'product-add',
    component: ProductAdd
  },
  {
    path: '/product/edit/:id',
    name: 'product-edit',
    component: ProductEdit
  },

  /////////////////////////////////

  {
    path: '/recipient',
    name: 'recipient-list',
    component: RecipientList
  },
  {
    path: '/recipient/add',
    name: 'recipient-add',
    component: RecipientAdd
  },
  {
    path: '/recipient/edit/:id',
    name: 'recipient-edit',
    component: RecipientEdit
  },

]

const router = new VueRouter({
  routes
})

export default router
