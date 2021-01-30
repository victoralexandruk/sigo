const serverUrl = "https://localhost:49159";
// const serverUrl = "http://bluelake.brazilsouth.cloudapp.azure.com/sigo";

/* api client ================================================================*/
const apiUrl = serverUrl + "/api";

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
        url: serverUrl + '/user/login',
        dataType: "text",
        contentType: "application/json",
        data: JSON.stringify({username, password})
      }).done(function (response) {
        localStorage.setItem('sigo_token', response);
        resolve(response);
      }).fail(reject);
    });
  },
  getNormas: function () {
    return this.ajax({
      type: "GET",
      url: apiUrl + '/norma',
      dataType: "json"
    });
  },
  getNorma: function (id) {
    return this.ajax({
      type: "GET",
      url: apiUrl + '/norma/' + id,
      dataType: "json"
    });
  },
  saveNorma: function (norma) {
    return this.ajax({
      type: "POST",
      url: apiUrl + '/norma',
      dataType: "json",
      contentType: "application/json",
      data: JSON.stringify(norma)
    });
  }
};
