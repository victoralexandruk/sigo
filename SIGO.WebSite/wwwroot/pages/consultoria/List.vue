<template>
  <div>
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
      <h1 class="h2">{{traducao('Consultorias / Assessorias')}}</h1>
      <div class="btn-toolbar mb-2 mb-md-0">
        <div class="input-group">
          <div class="input-group-prepend">
            <i class="input-group-text bg-white border-right-0 icon-search"></i>
          </div>
          <input type="text" class="form-control form-control-sm border-left-0" v-model="filter" placeholder="Pesquisar...">
        </div>
        <router-link to="/consultoria/0" class="btn btn-sm btn-outline-secondary ml-2">
          <i class="icon-plus-circle"></i>
          {{traducao('Novo')}}
        </router-link>
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
            <th>Área(s)</th>
            <th>CNPJ</th>
            <th>Vigência</th>
            <th class="text-center" style="width: 74px;">Em Vigor</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="consultoria in filteredConsultorias">
            <td class="align-middle">{{consultoria.tipo}}</td>
            <td class="align-middle">{{consultoria.area}}</td>
            <td class="align-middle">{{consultoria.cnpj}}</td>
            <td class="align-middle">{{$moment(consultoria.dataInicio).format('DD/MM/YY')}} - {{$moment(consultoria.dataTermino).format('DD/MM/YY')}}</td>
            <td class="align-middle text-center"><i class="font-weight-bold text-success" :class="{'icon-check': consultoria.status === 'Em Vigor'}"></i></td>
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
      consultorias: null,
      filter: ''
    };
  },
  computed: {
    filteredConsultorias: function () {
      try {
        return this.consultorias.filter(a => JSON.stringify(a).toLowerCase().indexOf(this.filter.toLowerCase()) !== -1);
      } catch (e) {
        return null;
      }
    }
  },
  methods: {
  },
  created: function () {
    api.getContratos().then(consultorias => this.consultorias = consultorias);
  }
}
</script>
