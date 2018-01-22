Application.controller("userController", function ($scope, $http, $location, customerService) {

	$scope.users = [{
		Id: 1, Name: "User1", Email: "Email1", Mobile: "Mobile1", UserName: "user_1", Password: "user_1", Department: "dep1"
	},
	{
		Id: 2, Name: "User2", Email: "Email2", Mobile: "Mobile2", UserName: "user_2", Password: "user_2", Department: "dep2"
	},
	{
		Id: 3, Name: "User3", Email: "Email3", Mobile: "Mobile3", UserName: "user_3", Password: "user_3", Department: "dep3"
	}];

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