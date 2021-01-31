<template lang="html">
  <nav id="sidebarMenu" class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse">
    <div class="sidebar-sticky pt-3">
      <ul class="nav flex-column">
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

      <h6 class="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
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
      </ul>
    </div>
  </nav>
</template>

<style lang="css" scoped>
</style>
