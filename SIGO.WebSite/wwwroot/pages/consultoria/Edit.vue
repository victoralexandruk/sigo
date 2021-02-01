<template>
  <div>
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
      <h3>{{traducao('Contrato')}}</h3>
      <div class="btn-toolbar mb-2 mb-md-0">
        <!-- <button type="button" class="btn btn-sm btn-outline-secondary">Export</button> -->
      </div>
    </div>
    <div v-if="!consultoria" class="d-flex justify-content-center">
      <div class="spinner-border text-primary" role="status">
        <span class="sr-only">Loading...</span>
      </div>
    </div>
    <div v-if="consultoria">
      <!-- <h5>Contrato</h5> -->
      <div class="table-responsive">
        <table class="table table-striped table-sm">
          <tbody>
            <tr>
              <th class="w-25">Tipo</th>
              <td>{{consultoria.tipo}}</td>
            </tr>
            <tr>
              <th>Data de Início</th>
              <td>{{moment(consultoria.dataInicio).format('DD/MM/YYYY')}}</td>
            </tr>
            <tr>
              <th>Data de Término</th>
              <td>{{moment(consultoria.dataTermino).format('DD/MM/YYYY')}}</td>
            </tr>
            <tr>
              <th>Área</th>
              <td>{{consultoria.area}}</td>
            </tr>
            <tr>
              <th>Status</th>
              <td>{{consultoria.status}}</td>
            </tr>
          </tbody>
        </table>
      </div>

      <h5 class="mt-3">Empresa</h5>
      <div v-if="consultoria.empresa" class="table-responsive">
        <table class="table table-striped table-sm">
          <tbody>
            <tr>
              <th class="w-25">CNPJ</th>
              <td>{{consultoria.empresa.cnpj}}</td>
            </tr>
            <tr>
              <th>Razão Social</th>
              <td>{{consultoria.empresa.razaoSocial}}</td>
            </tr>
            <tr>
              <th>Nome Fantasia</th>
              <td>{{consultoria.empresa.nomeFantasia}}</td>
            </tr>
            <tr>
              <th>Situação</th>
              <td>{{consultoria.empresa.situacao}}</td>
            </tr>
          </tbody>
        </table>
      </div>

      <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center">
        <h5 class="mt-3">Ações Planejadas</h5>
        <div class="btn-toolbar mb-2 mb-md-0">
          <button type="button" class="btn btn-sm btn-outline-secondary">
            <i class="icon-plus-circle"></i>
            {{traducao('Novo')}}
          </button>
        </div>
      </div>
      <div class="table-responsive">
        <table class="table table-striped table-sm">
          <thead>
            <tr>
              <th class="w-75">Descrição</th>
              <th>Norma</th>
              <th>Atualizado em</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-if="!acoesPlanejadas.length">
              <td colspan="4" class="font-weight-bold text-muted font-italic py-2">Sem ações planejadas</td>
            </tr>
            <tr v-for="acao in acoesPlanejadas">
              <td class="align-middle">{{acao.descricao}}</td>
              <td class="align-middle">{{acao.codigoNorma}}</td>
              <td class="align-middle">{{acao.dataAtualizacao}}</td>
              <td class="align-middle text-right">
                <button type="button" class="btn btn-sm btn-outline-secondary"><i class="icon-edit-2"></i></button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <!-- <pre>{{consultoria}}</pre> -->
    </div>
  </div>
</template>

<script>
module.exports = {
  data: function () {
    return {
      consultoria: null,
      acoesPlanejadas: []
    };
  },
  methods: {
  },
  created: function () {
    api.getContrato(this.$route.params.id).then(consultoria => this.consultoria = consultoria);
  }
}
</script>
