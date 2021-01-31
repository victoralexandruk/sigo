<template lang="html">
  <!-- <header class="masthead mb-auto">
    <div class="inner">
      <h3 class="masthead-brand">SIGO</h3>
      <nav class="nav nav-masthead justify-content-center">
        <router-link to="/" class="nav-link">{{traducao('Entrar')}}</router-link>
        <router-link to="/cadastrar" class="nav-link">{{traducao('Cadastrar')}}</router-link>
        <div class="dropdown">
          <a class="nav-link dropdown-toggle" href="#" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">{{traducao(idioma)}}</a>
          <div class="dropdown-menu dropdown-menu-right">
            <h6 class="dropdown-header">{{traducao('Idiomas')}}</h6>
            <a v-for="item in idiomasDisponiveis" class="dropdown-item" href="#" :class="{active: item === idioma}" @click.prevent="carregarIdioma(item)">{{traducao(item)}}</a>
          </div>
        </div>
      </nav>
    </div>
  </header> -->
  <nav class="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow">
    <router-link to="/" class="navbar-brand col-md-3 col-lg-2 mr-0 px-3 py-1">
      <i class="icon-sigo h2"></i>
    </router-link>
    <button class="navbar-toggler position-absolute d-md-none collapsed" type="button" data-toggle="collapse" data-target="#sidebarMenu" aria-controls="sidebarMenu" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <!-- <input class="form-control form-control-dark w-100 d-none d-md-block" type="text" placeholder="Search" aria-label="Search"> -->
    <ul class="navbar-nav px-3 d-none d-md-block">
      <li class="nav-item text-nowrap">
        <a class="nav-link" href="#" @click.prevent="logout()">{{traducao('Logout')}}</a>
      </li>
    </ul>
  </nav>
</template>

<script>
module.exports = {
  methods: {
    logout: function () {
      auth.logout();
      router.push('/login');
    }
  }
}
</script>

<style lang="css" scoped>
</style>
