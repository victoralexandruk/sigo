const store = {
  localizerStrings: {},
  idioma: 'pt-br',
  idiomasDisponiveis: ['pt-br', 'en'],
  apiInfo: null
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

const router = new VueRouter({
  routes: [
    { path: '/', component: httpVueLoader('pages/Home.vue') },
    { path: '/norma', component: httpVueLoader('pages/norma/List.vue') },
    { path: '/norma/:id', component: httpVueLoader('pages/norma/Edit.vue') },
  ],
  linkExactActiveClass: 'active'
});

var app = new Vue({
  el: '#app',
  router: router,
  created: function () {
    this.carregarIdioma();
  }
});
