<template>
  <div>
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
      <h1 class="h2">{{traducao('Dashboard')}}</h1>
      <!-- <div class="btn-toolbar mb-2 mb-md-0">
        <div class="btn-group mr-2">
          <button type="button" class="btn btn-sm btn-outline-secondary">Share</button>
          <button type="button" class="btn btn-sm btn-outline-secondary">Export</button>
        </div>
        <button type="button" class="btn btn-sm btn-outline-secondary dropdown-toggle">
          <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-calendar"><rect x="3" y="4" width="18" height="18" rx="2" ry="2"></rect><line x1="16" y1="2" x2="16" y2="6"></line><line x1="8" y1="2" x2="8" y2="6"></line><line x1="3" y1="10" x2="21" y2="10"></line></svg>
          This week
        </button>
      </div> -->
    </div>

    <div class="row">
      <div class="col-sm-6 col-md-4 col-lg-3 mb-3">
        <div class="card">
          <div class="card-body p-4 bg-dark text-center text-white">
            <i class="icon-file-text display-4"></i>
          </div>
          <div class="card-body">
            <h5 class="card-title">{{traducao('Normas')}}</h5>
            <p class="card-text">Visualize as normas e as ações necessárias para <i>compliance</i>.</p>
          </div>
        </div>
      </div>
      <div class="col-sm-6 col-md-4 col-lg-3 mb-3">
        <div class="card md-4">
          <div class="card-body p-4 bg-dark text-center text-white">
            <i class="icon-users display-4"></i>
          </div>
          <div class="card-body">
            <h5 class="card-title">{{traducao('Consultorias / Assessorias')}}</h5>
            <p class="card-text">Gerêncie contratos e gere insumos as diversas áreas da empresa.</p>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
module.exports = {
  data: function () {
    return {
    };
  },
  methods: {
  }
}
</script>
