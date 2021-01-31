<template lang="html">
  <div class="login">
    <div class="container d-flex h-100 p-3 mx-auto flex-column text-center">
      <header class="masthead mb-auto"></header>
      <main role="main" class="inner cover">
        <div class="card bg-dark form-signin">
          <div v-if="alert" class="alert" :class="alert.class">{{alert.title}}</div>
          <h2 class="cover-heading mb-4">
            <i class="icon-sigo display-4"></i>
          </h2>
          <form @submit.prevent="login()">
            <div class="lead">
              <input type="text" class="form-control" v-model="username" :placeholder="traducao('Username')" required>
              <input type="password" class="form-control" v-model="password" :placeholder="traducao('Password')" required>
            </div>
            <button type="submit" class="btn btn-lg btn-secondary btn-block mt-3">{{traducao('Entrar')}}</button>
          </form>
        </div>
        <div class="card bg-dark form-signin mt-3 p-3">
          <p class="mb-2">Use a conta de demonstração para fazer login:</p>
          <p class="m-0">Usuário: <strong>demo</strong> / Senha: <strong>demo</strong></p>
        </div>
      </main>
      <footer class="mastfoot mt-auto">
        <div class="inner">
          <p>{{company}}</p>
        </div>
      </footer>
    </div>
  </div>
</template>

<script>
module.exports = {
  data: function () {
    return {
      username: '',
      password: '',
      alert: null
    };
  },
  methods: {
    login: function () {
      api.login(this.username, this.password).then((response) => {
        if (response) {
          router.push(this.$route.query.redirect || { path: '/' });
        } else {
          this.alert = {
            title: traducao('Usuário e/ou senha inválido(s)'),
            class: "alert-warning"
          };
        }
      });
    }
  }
}
</script>

<style lang="css" scoped>
/* Custom default button */
.btn-secondary,
.btn-secondary:hover,
.btn-secondary:focus {
  color: #333;
  text-shadow: none; /* Prevent inheritance from `body` */
  background-color: #fff;
  border: .05rem solid #fff;
}

.login {
  display: -ms-flexbox;
  display: -webkit-box;
  display: flex;
  -ms-flex-pack: center;
  -webkit-box-pack: center;
  justify-content: center;
  color: #fff;
  box-shadow: inset 0 0 10rem 5rem rgba(0, 0, 0, 0.9);
  overflow: auto;
  height: 100%;
  background-image: url("../images/pexels-adrien-olichon-2387532.jpg");
  background-color: #333;
}

.cover-container {
  max-width: 42em;
}


/*
 * Header
 */
.masthead {
  margin-bottom: 2rem;
}

.masthead-brand {
  margin-bottom: 0;
}

.nav-masthead .nav-link {
  padding: .25rem 0;
  font-weight: 700;
  color: rgba(255, 255, 255, .5);
  background-color: transparent;
  border-bottom: .25rem solid transparent;
}

.nav-masthead .nav-link:hover,
.nav-masthead .nav-link:focus {
  border-bottom-color: rgba(255, 255, 255, .25);
}

.nav-masthead .nav-link {
  margin-left: 1rem;
}

.nav-masthead .active {
  color: #fff;
  border-bottom-color: #fff;
}

@media (min-width: 48em) {
  .masthead-brand {
    float: left;
  }
  .nav-masthead {
    float: right;
  }
}


/*
 * Cover
 */
.cover {
  padding: 0 1.5rem;
}
.cover .btn-lg {
  padding: .75rem 1.25rem;
  font-weight: 700;
}


/*
 * Footer
 */
.mastfoot {
  color: rgba(255, 255, 255, .5);
}

.form-signin {
  width: 100%;
  max-width: 330px;
  padding: 30px 20px;
  margin: 0 auto;
}
.form-signin .form-control {
  position: relative;
  box-sizing: border-box;
  height: auto;
  padding: 10px;
  font-size: 16px;
}
.form-signin .form-control:focus {
  z-index: 2;
}
.form-signin input:nth-child(1) {
  margin-bottom: -1px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
}
.form-signin input:nth-child(2) {
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}
</style>
