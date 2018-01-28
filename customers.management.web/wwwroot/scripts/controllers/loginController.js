Application.controller("loginController", function ($scope, $http, $location, loginService, accountService, $rootScope) {
	$scope.logined = loginService.getStatus();

	$scope.user = {
		UserName: "",
		Password: ""
	};

	$scope.callHeaderCtrl = function() {
		$rootScope.$emit("callHeaderCtrl", {});
	};

	$scope.signIn = function () {
		var url = "login/signin";
		if ($scope.user !== null) {
			$http.post(url, $scope.user).then(function successCallback(response) {
				var isAdmin = response.data.isAdmin;
				var username = response.data.userName;
				$scope.logined = true;
				loginService.setStatus($scope.logined);

				if (isAdmin) {
					$location.path("/adminPage");
				} else {
					accountService.setLogin(username);
					$location.path("/userPage");
				}

				$scope.callHeaderCtrl();
			}, function errorCallback() {
				alert("User not found!");
			});
		}
	};
});