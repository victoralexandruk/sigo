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
      <pre>{{norma}}</pre>
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
