Application.controller("addCustomerDetailsController", function ($scope, $http, $location) {
	$scope.addedUsers = [];
	$scope.addedContacts = [];
	$scope.addedDepartments = [];

	$scope.custName = "";
	$scope.custAddress = "";
	$scope.custEmail = "";
	$scope.custPhone = "";
	$scope.custComments = "";
	$scope.selectedTypeId = "2";
	$scope.custSchoolNumber = "";
	$scope.ifMunicipality = false;

	$scope.types = [
		{
			id: 1,
			name: "Municipality"
		},
		{
			id: 2,
			name: "Business"
		}];

	$scope.showSchoolNumbers = function () {
		if ($scope.selectedTypeId === "1") {
			$scope.ifMunicipality = true;
		}
		else
			if ($scope.selectedTypeId === "2") {
				$scope.ifMunicipality = false;
			}
	};

	$scope.addContact = function () {
		$scope.addedContacts.unshift({
			id: null, name: null, role: null,
			phone: null, customerId: null
		});
		console.log($scope.addedContacts);
	};

	$scope.addDepartment = function () {
		$scope.addedDepartments.unshift({
			id: "", name: null, address: null,
			manager: null
		});
		console.log($scope.addedDepartments);
	};

	$scope.addUser = function () {
		$scope.addedUsers.unshift({
			id: "", name: null, email: null,
			mobile: null, userName: null,
			password: null, department: null,
			customerId: null
		});
		console.log($scope.addedUsers);
	};

	$scope.deleteUser = function (index) {
		for (var i = 0; i < $scope.addedUsers.length; i++) {
			if (index === i) {
				$scope.addedUsers.splice(index, 1);
			}
		}
		console.log("user deleted");
	};

	$scope.deleteContact = function (index) {
		for (var i = 0; i < $scope.addedContacts.length; i++) {
			if (index === i) {
				$scope.addedContacts.splice(index, 1);
			}
		}
		console.log("contact deleted");
	};

	$scope.deleteDepartment = function (index) {
		for (var i = 0; i < $scope.addedDepartments.length; i++) {
			if (index === i) {
				$scope.departments.splice(index, 1);
			}
		}
		console.log("department deleted");
	};

	$scope.cancel = function () {
		$scope.addedUsers = [];
		$scope.addedContacts = [];
		$scope.addedDepartments = [];
		$scope.custName = "";
		$scope.custAddress = "";
		$scope.custEmail = "";
		$scope.custPhone = "";
		$scope.custComments = "";
		$scope.selectedTypeId = "2";
		$scope.custSchoolNumber = "";
		$scope.ifMunicipality = false;

		$location.path("/adminPage");
	};

	$scope.apply = function () {
		var customer = {};

		if ($scope.selectedTypeId === "1") {
			customer = {
				id: null,
				name: $scope.custName,
				address: $scope.custAddress,
				email: $scope.custEmail,
				phone: $scope.custPhone,
				comments: $scope.custComments,
				typeId: $scope.selectedTypeId,
				numberOfSchool: $scope.custSchoolNumber
			};
		}
		else if ($scope.selectedTypeId === "2") {
			customer = {
				id: null,
				name: $scope.custName,
				address: $scope.custAddress,
				email: $scope.custEmail,
				phone: $scope.custPhone,
				comments: $scope.custComments,
				typeId: $scope.selectedTypeId
			};
		}

		var customerDetailsToAdd = {
			Customer: customer,
			Departments: $scope.addedDepartments,
			Users: $scope.addedUsers,
			Contacts: $scope.addedContacts
		};


		var addurl = "customerdetails/addcustomerdetails";
		$http.post(addurl, customerDetailsToAdd).then(function () {
			$scope.cancel();
		}, function () {
		});
	};
});