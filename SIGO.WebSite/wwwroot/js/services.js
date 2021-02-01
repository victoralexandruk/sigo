// const websiteUrl = "https://localhost:49159";
// const websiteUrl = "https://bluelake.brazilsouth.cloudapp.azure.com/sigo/website";
const websiteUrl = location.origin + location.pathname.replace(/\/$/, '');

const apiUrls = {};

const auth = {
  isLoggedIn: function () {
    return localStorage.getItem('sigo_token') != null;
  },
  logout: function () {
    localStorage.removeItem('sigo_token');
  }
};

/* api client ================================================================*/
const api = {
  getToken: function () {
    return new Promise(function (resolve, reject) {
      var token = localStorage.getItem('sigo_token');
      resolve(token);
    });
  },
  ajax: function (options) {
    return new Promise((resolve, reject) => {
      this.getToken().then(function (token) {
        options.beforeSend = function (xhr) {
          xhr.setRequestHeader('Authorization', 'Bearer ' + token);
        };
        $.ajax(options).done(resolve).fail(reject);
      }).catch(reject);
    });
  },
  login: function (username, password) {
    return new Promise(function (resolve, reject) {
      $.ajax({
        type: "POST",
        url: websiteUrl + '/login',
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify({username, password})
      }).done(function (response) {
        if (response && response.token) {
          localStorage.setItem('sigo_token', response.token);
        }
        resolve(response);
      }).fail(reject);
    });
  },
  getInfo: function () {
    return this.ajax({
      type: "GET",
      url: websiteUrl + '/info',
      dataType: "json"
    });
  },
  /* Normas ========================================================= */
  getNormas: function () {
    return this.ajax({
      type: "GET",
      url: apiUrls.normas + '/norma',
      dataType: "json"
    });
  },
  getNorma: function (id) {
    return this.ajax({
      type: "GET",
      url: apiUrls.normas + '/norma/' + id,
      dataType: "json"
    });
  },
  saveNorma: function (norma) {
    return this.ajax({
      type: "POST",
      url: apiUrls.normas + '/norma',
      dataType: "json",
      contentType: "application/json",
      data: JSON.stringify(norma)
    });
  },
  /* Consultorias ========================================================= */
  getEmpresas: function () {
    return this.ajax({
      type: "GET",
      url: apiUrls.consultorias + '/empresa',
      dataType: "json"
    });
  },
  getEmpresa: function (id) {
    return this.ajax({
      type: "GET",
      url: apiUrls.consultorias + '/empresa/' + id,
      dataType: "json"
    });
  },
  saveEmpresa: function (empresa) {
    return this.ajax({
      type: "POST",
      url: apiUrls.consultorias + '/empresa',
      dataType: "json",
      contentType: "application/json",
      data: JSON.stringify(empresa)
    });
  }
};

api.getInfo().then(function (response) {
  $.each(response.webApi, function (key, value) {
    apiUrls[key] = value;
  });
});
