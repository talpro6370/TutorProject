angular.module("tutor_app", []).controller("Login-Controller", function ($scope, $http) {
    $scope.username = null;
    $scope.password = null;
    $scope.Post_data = function (username,password) {
        var data = {
            username: username,
            password: password
        };
    
        $scope.onSubmit = function () {
        $http.post("/api/TutorLoginCtrl/LoginData", JSON.stringify(data)).then(function (response) {
            var dataFromCtrl = response.data;
            if (response.data) {
                $.ajax({
                    url: "/Token",
                    type: "POST",
                    contentType: 'application/json',
                    data: {
                        username: data.username,
                        password: data.password,
                        grant_type: 'password'
                    },
                    
                    success: function (response) {
                        const Toast = Swal.mixin({
                            toast: true,
                            position: 'top-end',
                            showConfirmButton: false,
                            timer: 2000,
                            timerProgressBar: true,
                            width: '300px',
                            background: '#21dc35',
                            onOpen: (toast) => {
                                toast.addEventListener('mouseenter', Swal.stopTimer)
                                toast.addEventListener('mouseleave', Swal.resumeTimer)
                            }
                        })
                        sessionStorage.setItem('userName', response.userName);
                        sessionStorage.setItem('accessToken', response.access_token);
                        if (dataFromCtrl != null) {
                            Toast.fire({
                                icon: 'success',
                                customClass: 'customize',
                                title: 'Register successfully!'
                            });
                            window.href = "http://localhost:49294/Pages/TutorHomePage";
                        }  
                         else if (dataFromCtrl == null) {
                            swal.fire({
                                icon: 'warning',
                                title: 'Unexpected token ',
                                text: 'Please try again',
                                timerProgressBar: true,
                                allowOutsideClick: false,
                                timer: 3000
                            }).then(function() {
                                window.location.reload();
                            })
                                
                        }     
                    },
                    error: function () {
                        swal.fire({
                            icon: 'warning',
                            title: 'Unexpected token ',
                            text: 'Please try again',
                            timerProgressBar: true,
                            allowOutsideClick: false,
                            timer: 3000
                        });
                    }
                })
            }
        })
        }
        $scope.Logout = function () {
            sessionStorage.clear();
            Location.href("");
        }
    }
})