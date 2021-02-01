<template>
  <div>
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
      <h4 v-if="norma">{{norma.codigo}}</h4>
      <div class="btn-toolbar mb-2 mb-md-0">
        <button type="button" class="btn btn-sm btn-outline-secondary"><i class="icon-link"></i> {{traducao('Abrir')}}</button>
      </div>
    </div>
    <div v-if="!norma" class="d-flex justify-content-center">
      <div class="spinner-border text-primary" role="status">
        <span class="sr-only">Loading...</span>
      </div>
    </div>
    <div v-if="norma">
      <h5>Resumo</h5>
      <div class="table-responsive">
        <table class="table table-striped table-sm">
          <tbody>
            <tr>
              <th>Código</th>
              <td>{{norma.codigo}}</td>
            </tr>
            <tr>
              <th>Título</th>
              <td>{{norma.titulo}}</td>
            </tr>
            <tr>
              <th>Data de Publicação</th>
              <td>{{$moment(norma.dataPublicacao).format('DD/MM/YYYY')}}</td>
            </tr>
            <tr>
              <th>Comitê</th>
              <td>{{norma.comite}}</td>
            </tr>
            <tr>
              <th>Páginas</th>
              <td>{{norma.paginas}}</td>
            </tr>
            <tr>
              <th>Status</th>
              <td>{{norma.status}}</td>
            </tr>
            <tr>
              <th>Idioma</th>
              <td>{{norma.idioma}}</td>
            </tr>
            <tr>
              <th>Organismo</th>
              <td>{{norma.organismo}}</td>
            </tr>
            <tr>
              <th>Objetivo</th>
              <td>{{norma.objetivo}}</td>
            </tr>
            <tr>
              <th>Arquivo</th>
              <td>{{norma.caminhoArquivo}}</td>
            </tr>
          </tbody>
        </table>
      </div>
      <h5>Ações Planejadas</h5>
      <div class="table-responsive">
        <table class="table table-striped table-sm">
          <thead>
            <tr>
              <th class="w-50">Descrição</th>
              <th>Responsável</th>
              <th>Atualizado em</th>
            </tr>
          </thead>
          <tbody>
            <tr v-if="!norma.acoesPlanejadas.length">
              <td colspan="3" class="font-weight-bold text-muted font-italic py-2">Sem ações planejadas</td>
            </tr>
            <tr v-for="acao in norma.acoesPlanejadas">
              <td class="align-middle">{{acao.descricao}}</td>
              <td class="align-middle">{{acao.responsavel}}</td>
              <td class="align-middle">{{$moment.utc(acao.dataAtualizacao).local().format('DD/MM/YYYY HH:mm')}}</td>
            </tr>
          </tbody>
        </table>
      </div>
      <!-- <pre>{{norma}}</pre> -->
    </div>
  </div>
</template>

<script>
module.exports = {
  data: function () {
    return {
      norma: null
    };
  },
  methods: {
  },
  created: function () {
    api.getNorma(this.$route.params.id).then(norma => this.norma = norma);
  }
}
</script>
