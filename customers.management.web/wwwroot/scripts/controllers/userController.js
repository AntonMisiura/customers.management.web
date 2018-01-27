Application.controller("userController", function ($scope, $http, $location, customerService, customerStorage) {
	$scope.customerId = customerStorage.getId();
	$scope.users = [];
	$scope.showUsers = false;

	$scope.initUsers = function() {
		var url = "user/getbycustomerid/" + $scope.customerId;

		$http.get(url).then(function successCallback(response) {
			$scope.users = response.data;
			$scope.showUsers = true;
		}, function errorCallback() {
			alert("An error occured during loading users!");
		});
	};

	$scope.go = function (path) {
		$location.path(path);
	};

	$scope.editUser = function (user) {
		$scope.go("/user/edit");
		customerService.setData(user);
	};

	$scope.deleteUser = function (id) {
		for (var i = 0; i < $scope.users.length; i++) {
			if ($scope.users[i].Id === id) {
				$scope.users.splice(i, 1);
			}
		}
	};

	$scope.addUser = function () {
		$scope.go("/user/add");
	};
});