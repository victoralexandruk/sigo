<template>
  <div>
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
      <h1 class="h2">{{traducao('Normas')}}</h1>
      <div class="btn-toolbar mb-2 mb-md-0">
        <div class="input-group">
          <div class="input-group-prepend">
            <i class="input-group-text bg-white border-right-0 icon-search"></i>
          </div>
          <input type="text" class="form-control form-control-sm border-left-0" v-model="filter" placeholder="Pesquisar...">
        </div>
      </div>
    </div>
    <div v-if="!normas" class="d-flex justify-content-center">
      <div class="spinner-border text-primary" role="status">
        <span class="sr-only">Loading...</span>
      </div>
    </div>
    <div v-if="normas" class="table-responsive">
      <table class="table table-striped table-sm">
        <thead>
          <tr>
            <th>Código</th>
            <th>Título</th>
            <th class="text-center" style="width: 74px;">Em Vigor</th>
            <th class="text-center" style="width: 82px;">Qtd. Ações</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="norma in filteredNormas">
            <td class="align-middle">{{norma.codigo}}</td>
            <td class="align-middle">{{norma.titulo}}</td>
            <td class="align-middle text-center"><i class="font-weight-bold text-success" :class="{'icon-check': norma.status === 'Em Vigor'}"></i></td>
            <td class="align-middle text-center">{{norma.qtdAcoesPlanejadas}}</td>
            <td class="align-middle text-right">
              <router-link :to="'/norma/' + norma.id" class="btn btn-sm btn-outline-secondary"><i class="icon-eye"></i></router-link>
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
      normas: null,
      filter: ''
    };
  },
  computed: {
    filteredNormas: function () {
      try {
        return this.normas.filter(a => JSON.stringify(a).toLowerCase().indexOf(this.filter.toLowerCase()) !== -1);
      } catch (e) {
        return null;
      }
    }
  },
  methods: {
  },
  created: function () {
    api.getNormas().then(normas => this.normas = normas);
  }
}
</script>
