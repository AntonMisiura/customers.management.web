Application.controller("generalController", function ($scope, $http, $location, customerService) {

	$scope.customers = [{
		Id: 1, Name: "custom1", Address: "adr1", Email: "Email1", Phone: "Mobile1", Comments: "comment1"
	},
	{
		Id: 2, Name: "custom2", Address: "adr2", Email: "Email2", Phone: "Mobile2", Comments: "comment2"
	},
	{
		Id: 3, Name: "custom3", Address: "adr3", Email: "Email3", Phone: "Mobile3", Comments: "comment3"
	}];

	$scope.contacts = [{
		Id: 1, Name: "cont1", Role: "role1", Email: "Email1", Phone: "Mobile1"
	},
	{
		Id: 2, Name: "cont2", Role: "role2", Email: "Email2", Phone: "Mobile2"
	},
	{
		Id: 3, Name: "cont3", Role: "role3", Email: "Email3", Phone: "Mobile3"
	}];

	$scope.go = function (path) {
		$location.path(path);
	};

	$scope.editCustomer = function (cust) {
		$scope.go("/customer/edit");
		customerService.setData(cust);
	};

	$scope.deleteCustomer = function (id) {
		for (var i = 0; i < $scope.customers.length; i++) {
			if ($scope.customers[i].Id === id) {
				$scope.customers.splice(i, 1);
			}
		}
	};

	$scope.editContact = function (cont) {
		$scope.go("/contact/edit");
		customerService.setData(cont);
	};

	$scope.deleteContact = function (id) {
		for (var i = 0; i < $scope.contacts.length; i++) {
			if ($scope.contacts[i].Id === id) {
				$scope.contacts.splice(i, 1);
			}
		}
	};

	$scope.addCustomer = function() {
		$scope.go("/customer/add");
	};

	$scope.addContact = function () {
		$scope.go("/contact/add");
	};
});