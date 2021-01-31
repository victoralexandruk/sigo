<template lang="html">
	<div>
		<topbar></topbar>
    <div class="container-fluid">
      <div class="row">
        <sidebar></sidebar>
        <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-md-4">
    			<router-view></router-view>
    		</main>
      </div>
    </div>
	</div>
</template>
