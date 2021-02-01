<template>
  <div>
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
      <h3>{{traducao('Contrato')}}</h3>
      <div class="btn-toolbar mb-2 mb-md-0">
        <!-- <button type="button" class="btn btn-sm btn-outline-secondary">Export</button> -->
      </div>
    </div>
    <div v-if="!contrato" class="d-flex justify-content-center">
      <div class="spinner-border text-primary" role="status">
        <span class="sr-only">Loading...</span>
      </div>
    </div>
    <div v-if="contrato">
      <!-- <h5>Contrato</h5> -->
      <div class="table-responsive">
        <table class="table table-striped table-sm">
          <tbody>
            <tr>
              <th class="w-25">Tipo</th>
              <td>{{contrato.tipo}}</td>
            </tr>
            <tr>
              <th>Data de Início</th>
              <td>{{$moment(contrato.dataInicio).format('DD/MM/YYYY')}}</td>
            </tr>
            <tr>
              <th>Data de Término</th>
              <td>{{$moment(contrato.dataTermino).format('DD/MM/YYYY')}}</td>
            </tr>
            <tr>
              <th>Área</th>
              <td>{{contrato.area}}</td>
            </tr>
            <tr>
              <th>Status</th>
              <td>{{contrato.status}}</td>
            </tr>
          </tbody>
        </table>
      </div>

      <h5 class="mt-3">Empresa</h5>
      <div v-if="contrato.empresa" class="table-responsive">
        <table class="table table-striped table-sm">
          <tbody>
            <tr>
              <th class="w-25">CNPJ</th>
              <td>{{contrato.empresa.cnpj}}</td>
            </tr>
            <tr>
              <th>Razão Social</th>
              <td>{{contrato.empresa.razaoSocial}}</td>
            </tr>
            <tr>
              <th>Nome Fantasia</th>
              <td>{{contrato.empresa.nomeFantasia}}</td>
            </tr>
            <tr>
              <th>Situação</th>
              <td>{{contrato.empresa.situacao}}</td>
            </tr>
          </tbody>
        </table>
      </div>

      <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center">
        <h5 class="mt-3">Ações Planejadas</h5>
        <div class="btn-toolbar mb-2 mb-md-0">
          <button type="button" class="btn btn-sm btn-outline-secondary" @click="openModalAcaoPlanejada()">
            <i class="icon-plus-circle"></i>
            {{traducao('Novo')}}
          </button>
        </div>
      </div>
      <div class="table-responsive">
        <table class="table table-striped table-sm">
          <thead>
            <tr>
              <th class="w-50">Descrição</th>
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
              <td class="align-middle">{{$moment.utc(acao.dataAtualizacao).local().format('DD/MM/YYYY HH:mm')}}</td>
              <td class="align-middle text-right">
                <button type="button" class="btn btn-sm btn-outline-secondary" @click="openModalAcaoPlanejada(acao)"><i class="icon-edit-2"></i></button>
                <button type="button" class="btn btn-sm btn-outline-secondary" @click="deleteAcaoPlanejada(acao.id)"><i class="icon-trash-2"></i></button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <!-- <pre>{{contrato}}</pre> -->
      <modal-acao-planejada :acao-planejada="editAcaoPlanejada" @save="loadAcoesPlanejadas()"></modal-acao-planejada>
    </div>
  </div>
</template>

<script>
module.exports = {
  data: function () {
    return {
      contrato: null,
      acoesPlanejadas: [],
      editAcaoPlanejada: null
    };
  },
  methods: {
    loadAcoesPlanejadas: function () {
      api.searchAcoesPlanejadas('idContrato', this.$route.params.id, true).then(acoesPlanejadas => this.acoesPlanejadas = acoesPlanejadas);
    },
    openModalAcaoPlanejada: function (acaoPlanejada) {
      if (acaoPlanejada) {
        acaoPlanejada = JSON.parse(JSON.stringify(acaoPlanejada));
        delete acaoPlanejada.dataAtualizacao;
      }
      this.editAcaoPlanejada = acaoPlanejada || {
        idContrato: this.contrato.id,
        codigoNorma: '',
        descricao: '',
        responsavel: this.contrato.empresa.razaoSocial
      };
      $('#modalAcaoPlanejada').modal('show');
    },
    deleteAcaoPlanejada: function (id) {
      api.deleteAcaoPlanejada(id).then(() => {
        this.loadAcoesPlanejadas();
      });
    }
  },
  created: function () {
    api.getContrato(this.$route.params.id).then(contrato => this.contrato = contrato);
    this.loadAcoesPlanejadas();
  }
}
</script>
