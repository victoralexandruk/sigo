<template lang="html">
  <header class="masthead mb-auto">
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
  </header>
</template>

<style lang="css" scoped>
</style>
