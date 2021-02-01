<template lang="html">
  <div class="modal fade" id="modalAcaoPlanejada" tabindex="-1" role="dialog">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <form v-if="acaoPlanejada" @submit.prevent="saveAcaoPlanejada()">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Ação Planejada</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <div class="form-group">
              <label>Norma</label>
              <input type="text" class="form-control" placeholder="Código da norma" v-model="acaoPlanejada.codigoNorma">
              <!-- <small class="form-text text-muted">We'll never share your email with anyone else.</small> -->
              <div v-if="filteredNormas && filteredNormas.length" class="list-group mt-2">
                <button v-for="norma in filteredNormas" type="button" class="list-group-item list-group-item-action text-truncate py-2 px-3" @click="acaoPlanejada.codigoNorma = norma.codigo">
                  <strong>{{norma.codigo}}</strong> {{norma.titulo}}
                </button>
              </div>
            </div>
            <div class="form-group">
              <label>Descrição</label>
              <textarea class="form-control" placeholder="Descrição..." v-model="acaoPlanejada.descricao"></textarea>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
            <button type="submit" class="btn btn-primary">Salvar</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
module.exports = {
  props: ['acaoPlanejada'],
  data: function () {
    return {
      normas: null
    };
  },
  computed: {
    filteredNormas: function () {
      try {
        if (this.acaoPlanejada.codigoNorma.length < 3) {
          return null;
        }
        return this.normas.filter(a => a.codigo !== this.acaoPlanejada.codigoNorma && a.codigo.toLowerCase().indexOf(this.acaoPlanejada.codigoNorma.toLowerCase()) !== -1).slice(0, 5);
      } catch (e) {
        return null;
      }
    }
  },
  methods: {
    saveAcaoPlanejada: function () {
      api.saveAcaoPlanejada(this.acaoPlanejada).then((response) => {
        this.$emit('save', response);
        $('#modalAcaoPlanejada').modal('hide');
        notyf.success('Ação planejada salva!');
      });
    }
  },
  created: function () {
    api.getNormas().then(normas => this.normas = normas);
  }
}
</script>

<style lang="css" scoped>
</style>
