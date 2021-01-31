<template>
  <div>
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
      <h1 class="h2">{{traducao('Consultorias / Assessorias')}}</h1>
      <div class="btn-toolbar mb-2 mb-md-0">
        <button type="button" class="btn btn-sm btn-outline-secondary"><i class="icon-plus-circle"></i> {{traducao('Novo')}}</button>
      </div>
    </div>
    <div v-if="!consultorias" class="d-flex justify-content-center">
      <div class="spinner-border text-primary" role="status">
        <span class="sr-only">Loading...</span>
      </div>
    </div>
    <div v-if="consultorias" class="table-responsive">
      <table class="table table-striped table-sm">
        <thead>
          <tr>
            <th>Tipo</th>
            <th>Nome</th>
            <th>Área(s)</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="consultoria in consultorias">
            <td class="align-middle">{{consultoria.tipo}}</td>
            <td class="align-middle">{{consultoria.nome}}</td>
            <td class="align-middle">{{consultoria.area}}</td>
            <td class="align-middle text-right">
              <router-link :to="'/consultoria/' + consultoria.id" class="btn btn-sm btn-outline-secondary"><i class="icon-edit-2"></i></router-link>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
module.exports = {
  data: function () {
    return {
      consultorias: null
    };
  },
  methods: {
  },
  created: function () {
    api.getConsultorias().then(consultorias => this.consultorias = consultorias);
  }
}
</script>
