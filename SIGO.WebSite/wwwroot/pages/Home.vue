<template>
  <div class="form-signin">
    <h2 class="cover-heading mb-4">{{traducao('Entrar')}}</h2>
    <form @submit.prevent="login()">
      <div class="lead">
        <input type="text" class="form-control" v-model="username" :placeholder="traducao('Username')" required>
        <input type="password" class="form-control" v-model="password" :placeholder="traducao('Password')" required>
      </div>
      <button type="submit" class="btn btn-lg btn-secondary btn-block mt-2">{{traducao('Entrar')}}</button>
    </form>
  </div>
</template>

<script>
module.exports = {
  data: function () {
    return {
      username: '',
      password: ''
    };
  },
  methods: {
    login: function () {
      api.login(this.username, this.password).then((response) => {
        console.log(response);
      });
    }
  }
}
</script>
