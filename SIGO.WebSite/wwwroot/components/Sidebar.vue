<template lang="html">
  <nav id="sidebarMenu" class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse">
    <div class="sidebar-sticky pt-3">
      <ul class="nav flex-column">
        <li class="nav-item">
          <router-link to="/" class="nav-link">
            <i class="icon-home"></i>
            Dashboard
          </router-link>
        </li>
        <li class="nav-item">
          <router-link to="/norma" class="nav-link">
            <i class="icon-file"></i>
            Normas
          </router-link>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">
            <i class="icon-users"></i>
            Customers
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">
            <i class="icon-bar-chart-2"></i>
            Reports
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">
            <i class="icon-layers"></i>
            Integrations
          </a>
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
            <i class="icon-file-text"></i>
            Current month
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">
            <i class="icon-file-text"></i>
            Last quarter
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">
            <i class="icon-file-text"></i>
            Social engagement
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">
            <i class="icon-file-text"></i>
            Year-end sale
          </a>
        </li>
      </ul>
    </div>
  </nav>
</template>

<style lang="css" scoped>
</style>
