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
  uploadArquivoNorma: function (id, file) {
    var formData = new FormData();
    formData.append('formFile', file);
    return this.ajax({
      type: "POST",
      url: apiUrls.normas + '/norma/arquivo/' + id,
      contentType: false,
      processData: false,
      data: formData
    });
  },
  downloadArquivoNorma: function (id) {
    return new Promise((resolve, reject) => {
      this.ajax({
        type: "GET",
        url: apiUrls.normas + '/norma/arquivo/' + id,
        cache: false,
        xhr: function() {
          var xhr = new XMLHttpRequest();
          xhr.responseType= 'blob';
          return xhr;
        }
      }).then(function (response) {
        var url = window.URL || window.webkitURL;
        resolve(url.createObjectURL(response));
      }).catch(reject);
    });
  },
  deleteArquivoNorma: function (id) {
    return this.ajax({
      type: "DELETE",
      url: apiUrls.normas + '/norma/arquivo/' + id
    });
  },
  getAcoesPlanejadas: function () {
    return this.ajax({
      type: "GET",
      url: apiUrls.normas + '/acaoplanejada',
      dataType: "json"
    });
  },
  getAcaoPlanejada: function (id) {
    return this.ajax({
      type: "GET",
      url: apiUrls.normas + '/acaoplanejada/' + id,
      dataType: "json"
    });
  },
  saveAcaoPlanejada: function (acaoPlanejada) {
    return this.ajax({
      type: "POST",
      url: apiUrls.normas + '/acaoplanejada',
      dataType: "json",
      contentType: "application/json",
      data: JSON.stringify(acaoPlanejada)
    });
  },
  deleteAcaoPlanejada: function (id) {
    return this.ajax({
      type: "DELETE",
      url: apiUrls.normas + '/acaoplanejada/' + id,
      // dataType: "json"
    });
  },
  searchAcoesPlanejadas: function (key, value, strict) {
    return this.ajax({
      type: "GET",
      url: apiUrls.normas + '/acaoplanejada/search/' + key + '/' + value + '/' + strict,
      dataType: "json"
    });
  },
  /* Consultorias ========================================================= */
  getContratos: function () {
    return this.ajax({
      type: "GET",
      url: apiUrls.consultorias + '/contrato',
      dataType: "json"
    });
  },
  getContrato: function (id) {
    return this.ajax({
      type: "GET",
      url: apiUrls.consultorias + '/contrato/' + id,
      dataType: "json"
    });
  },
  saveContrato: function (contrato) {
    return this.ajax({
      type: "POST",
      url: apiUrls.consultorias + '/contrato',
      dataType: "json",
      contentType: "application/json",
      data: JSON.stringify(contrato)
    });
  },
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
