<template lang="html">
  <nav id="sidebarMenu" class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse">
    <div class="sidebar-sticky pt-0">

      <div class="d-md-none border-bottom">
        <div class="d-flex align-items-end p-3 sidebar-pattern-bg text-white" style="height: 100px;">
          <h5 class="font-weight-light m-0"><i class="icon-user"></i> {{tokenData.given_name}}</h5>
        </div>
        <ul class="nav flex-column py-2">
          <!-- <li class="nav-item">
            <span class="nav-link p-3 bg-secondary text-white"><i class="icon-user"></i> {{tokenData.given_name}}</span>
          </li> -->
          <li class="nav-item">
            <a class="nav-link" href="#" @click.prevent="logout()">
              <i class="icon-log-out"></i>
              {{traducao('Logout')}}
            </a>
          </li>
        </ul>
      </div>

      <ul class="nav flex-column py-2">
        <li class="nav-item">
          <router-link to="/" class="nav-link">
            <i class="icon-home"></i>
            {{traducao('Dashboard')}}
          </router-link>
        </li>
        <li class="nav-item">
          <router-link to="/norma" class="nav-link">
            <i class="icon-file-text"></i>
            {{traducao('Normas')}}
          </router-link>
        </li>
        <li class="nav-item">
          <router-link to="/consultoria" class="nav-link">
            <i class="icon-users"></i>
            {{traducao('Consultorias / Assessorias')}}
          </router-link>
        </li>
      </ul>

      <!-- <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
        <span>Saved reports</span>
        <a class="d-flex align-items-center text-muted" href="#" aria-label="Add a new report">
          <i class="icon-plus-circle"></i>
        </a>
      </h6>
      <ul class="nav flex-column mb-2">
        <li class="nav-item">
          <a class="nav-link" href="#">
            <i class="icon-bar-chart-2"></i>
            Current month
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">
            <i class="icon-bar-chart-2"></i>
            Last quarter
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">
            <i class="icon-bar-chart-2"></i>
            Social engagement
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">
            <i class="icon-bar-chart-2"></i>
            Year-end sale
          </a>
        </li>
      </ul> -->
    </div>
  </nav>
</template>

<script>
module.exports = {
}
</script>

<style lang="css" scoped>
</style>
