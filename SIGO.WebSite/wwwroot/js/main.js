const store = {
  localizerStrings: {},
  idioma: 'pt-br',
  idiomasDisponiveis: ['pt-br', 'en'],
  company: 'IndTexBr'
};

function traducao(key) {
  return store.localizerStrings[key] || key;
}

Vue.mixin({
  data: function () {
    return store;
  },
  methods: {
    traducao: traducao,
    carregarIdioma: function (idioma) {
      if (idioma) {
        store.idioma = idioma;
      }
      $.get('lang/' + store.idioma + '.json').done(function (strings) {
        store.localizerStrings = strings;
      }).fail(function () {
        store.localizerStrings = {};
      });
    }
  }
});

Vue.component('topbar', httpVueLoader('components/Topbar.vue'));
Vue.component('sidebar', httpVueLoader('components/Sidebar.vue'));

const router = new VueRouter({
  routes: [
    { path: '/login', component: httpVueLoader('pages/Login.vue') },
    { path: '/', component: httpVueLoader('pages/BaseAuthenticated.vue'), meta: { requiresAuth: true }, children: [
      { path: '', component: httpVueLoader('pages/Home.vue'), meta: { requiresAuth: true } },
      { path: 'norma', component: httpVueLoader('pages/norma/List.vue') },
      { path: 'norma/:id', component: httpVueLoader('pages/norma/Edit.vue') },
      { path: 'consultoria', component: httpVueLoader('pages/consultoria/List.vue') },
      { path: 'consultoria/:id', component: httpVueLoader('pages/consultoria/Edit.vue') },
    ] },
  ],
  linkExactActiveClass: 'active'
});

router.beforeEach((to, from, next) => {
	if (to.path === '/login' && auth.isLoggedIn()) {
		next({ path: '/' });
	} else if (to.matched.some(record => record.meta.requiresAuth) && !auth.isLoggedIn()) {
		// this route requires auth, check if logged in if not, redirect to login page.
		next({
			path: '/login',
			query: { redirect: to.fullPath }
		});
	} else {
		// make sure to always call next()!
		next();
	}
});

var app = new Vue({
  el: '#app',
  router: router,
  created: function () {
    this.carregarIdioma();
  }
});
