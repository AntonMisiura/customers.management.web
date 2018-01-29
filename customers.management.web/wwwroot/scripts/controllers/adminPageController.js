Application.controller("adminPageController", function ($scope, $http) {
	$scope.selectedCustomerId = "";
	$scope.show = false;
	$scope.customers = [];
	$scope.contacts = [];
	$scope.departments = [];
	$scope.users = [];

	$scope.editCust = false;
	$scope.editUs = false;
	$scope.editCont = false;
	$scope.editDeps = false;



	$scope.initCustomers = function () {
		var url = "customerdetails/getallcustomers/";
		$http.get(url).then(function successCallback(response) {
			$scope.customers = response.data;
		}, function errorCallback() {
		});
	};

	$scope.selectCustomer = function () {
		$scope.getCustomerById();
		$scope.show = true;
	};

	$scope.getCustomerById = function () {
		var url = "customerdetails/getcustomerdetailsbyid/" + $scope.selectedCustomerId;
		$http.get(url).then(function successCallback(response) {
			$scope.contacts = response.data.contacts;
			$scope.users = response.data.customer.users;
			$scope.departments = response.data.departments;
		}, function errorCallback() {
		});
	};

	$scope.getManagers = function() {
		for (var i = 0; i < $scope.departments.length; i++) {
			for (var j = 0; j < $scope.users.length; j++) {
				if ($scope.departments[i].userId === $scope.users[j].id) {
					$scope.departments[i].manager = $scope.users[j];
				}
			}
		}
	};

	$scope.showManager = function(userId) {
		for (var i = 0; i < $scope.users.length; i++) {
			if ($scope.users[i].id === userId) {
				return $scope.users[i].name;
			}
		}
	};

	$scope.showUserDepartment = function (depId) {
		for (var i = 0; i < $scope.departments.length; i++) {
			if ($scope.departments[i].id === depId) {
				return $scope.departments[i].name;
			}
		}
	};

	$scope.addCustomer = function () {
		$scope.customers.unshift({
			Id: null, Name: null, Address: null,
			Email: null, Phone: null,
			Comments: null
		});
	};

	$scope.addContact = function () {
		$scope.contacts.unshift({
			Id: null, Name: null, Role: null,
			Phone: null, CustomerId: $scope.selectedCustomerId
		});
	};

	$scope.addDepartment = function () {
		$scope.departments.unshift({
			Id: null, Name: null, Address: null,
			Manager: null
		});
	};

	$scope.addUser = function () {
		$scope.users.unshift({
			Id: null, Name: null, Email: null,
			Mobile: null, UserName: null,
			Password: null, Department: null
		});
	};


	$scope.deleteUser = function(index, id) {
		for (var i = 0; i < $scope.users.length; i++) {
			if (id === $scope.users[i].id) {
				$scope.users.splice(i, 1);
			}
			else if (id === null && index === i) {
				$scope.users.splice(index, i);
			}
		}
	};

	$scope.deleteContact = function (index, id) {
		for (var i = 0; i < $scope.contacts.length; i++) {
			if (id === $scope.contacts[i].id) {
				$scope.contacts.splice(i, 1);
			}
			else if (id === null && index === i) {
				$scope.contacts.splice(index, i);
			}
		}
	};

	$scope.deleteDepartment = function (index, id) {
		for (var i = 0; i < $scope.departments.length; i++) {
			if (id === $scope.departments[i].id) {
				$scope.departments.splice(i, 1);
			}
			else if (id === null && index === i) {
				$scope.departments.splice(index, i);
			}
		}
	};

	$scope.deleteCustomer = function (index, id) {
		for (var i = 0; i < $scope.customers.length; i++) {
			if (id === $scope.customers[i].id) {
				$scope.customers.splice(i, 1);
			}
			else if (id === null && index === i) {
				$scope.customers.splice(index, i);
			}
		}
	};

	$scope.editCustomers = function() {
		$scope.editCust = true;
	};

	$scope.editContacts = function () {
		$scope.editCont = true;
	};

	$scope.editUsers = function () {
		$scope.editUs = true;
	};

	$scope.editDepartments = function () {
		$scope.editDeps = true;
	};

	$scope.cancel = function() {
		$scope.editCust = false;
		$scope.editCont = false;
		$scope.editUs = false;
		$scope.editDeps = false;

		$scope.findAndRemoveAdded($scope.users);
		$scope.findAndRemoveAdded($scope.contacts);
		$scope.findAndRemoveAdded($scope.customers);
		$scope.findAndRemoveAdded($scope.departments);
	};

	$scope.findAndRemoveAdded = function(list) {
		for (var i = 0; i < list.length; i++) {
			if (list[i].Id === null) {
				list.splice(i, 1);
			}
		}
	};

	$scope.apply = function() {

	};
});