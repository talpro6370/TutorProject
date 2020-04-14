angular.module("tutor_app", []).controller("Registration-Controller", function ($scope, $http) {
    $scope.first_name = null;
    $scope.last_name = null;
    $scope.user_name = null;
    $scope.password = null;
    $scope.email = null;
    $scope.phone_number = null;
    $scope.city = null;
    $scope.profession = null;
    $scope.gender = null;

    $scope.Post_data = function (first_name, last_name, user_name, password, email, phone_number,city, profession,gender) {
        var data = {
            first_name: first_name,
            last_name: last_name,
            user_name: user_name,
            password: password,
            email: email,
            phone_number: phone_number,
            city:city,
            profession: profession,
            gender:gender
        };
        $scope.onSubmit = function () {
            $http.post("/api/TutorRegistrationCtrl/SubmitData", JSON.stringify(data)).then(function (response) {
                var dataVal = {
                    UserName: $('#user_name').val().trim(),
                    Password: $('#password').val().trim(),
                    ConfirmPassword: $('#password').val().trim()
                }
                if (response.data) {
                    const Toast = Swal.mixin({
                        toast: true,
                        position: 'top-end',
                        showConfirmButton: false,
                        timer: 3000,
                        timerProgressBar: true,
                        width: '300px',
                        background: '#21dc35',
                        onOpen: (toast) => {
                            toast.addEventListener('mouseenter', Swal.stopTimer)
                            toast.addEventListener('mouseleave', Swal.resumeTimer)
                        }
                    })
                    Toast.fire({
                        icon: 'success',
                        customClass: 'customize',
                        title: 'Register successfully!'
                        
                    }).then(function () {
                        $.ajax({
                            url: "/api/Account/Register",
                            type: 'POST',
                            data: dataVal,
                            success: function () {
                                console.log("Auth completed!");
                                window.location.href ='http://localhost:49294/Pages/TutorLoginPage';
                            }, //Continue with getting the access-token from generator. Use dotnettricks website
                            error: function () {
                                console.log("Auth failed!");
                            }
                        })
                    })
                }
                
                else {
                    swal.fire({
                        icon: 'warning',
                        title: 'Username is already exist!',
                        text: 'Please try again',
                        timerProgressBar: true,
                        allowOutsideClick: false,
                        timer: 3000
                    });
                    setTimeout(() => {
                        location.reload();
                    }, 3000);
                }
        }
        )
        }
    }
   
    $scope.cities = [];
    $http.get('/api/DataController/GetCities').then(function (response) {
        $scope.cities = response.data;
    });
    $scope.profs = [];
    $http.get('/api/DataController/GetProfessions').then(function (response) {
        $scope.profs = response.data;
    });
 
})