Application.factory("accountService", function () {
	var login = "";

	var service = {
		setLogin: setLogin,
		getLogin: getLogin
	};

	return service;

	function setLogin(lg) {
		login = lg;
	}

	function getLogin() {
		return login;
	}
});