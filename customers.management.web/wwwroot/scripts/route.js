Application.config([
	"$routeProvider", function ($routeProvider) {
		$routeProvider
			.when("/general",
			{
				templateUrl: "views/general.html",
				controller: "generalController"
			})
			.when("/departments",
			{
				templateUrl: "views/departments.html",
				controller: "departmentController"
			})
			.when("/users",
			{
				templateUrl: "views/users.html",
				controller: "userController"
			})
			.when("/contact/edit",
			{
				templateUrl: "views/contactEdit.html",
				controller: "contactEditController"
			})
			.when("/department/edit",
			{
				templateUrl: "views/departmentEdit.html",
				controller: "departmentEditController"
			})
			.when("/customer/edit",
			{
				templateUrl: "views/customerEdit.html",
				controller: "customerEditController"
			})
			.when("/user/edit",
			{
				templateUrl: "views/userEdit.html",
				controller: "userEditController"
			})
			.when("/contact/add",
			{
				templateUrl: "views/addContact.html",
				controller: "addContactController"
			})
			.when("/department/add",
			{
				templateUrl: "views/addDepartment.html",
				controller: "addDepartmentController"
			})
			.when("/customer/add",
			{
				templateUrl: "views/addCustomer.html",
				controller: "addCustomerController"
			})
			.when("/user/add",
			{
				templateUrl: "views/addUser.html",
				controller: "addUserController"
			})
			.when("/login",
			{
				templateUrl: "views/login.html",
				controller: "loginController"
			});
	}
]);