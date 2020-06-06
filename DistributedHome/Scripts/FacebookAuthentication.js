function getAccessToken() {
    if (location.hash) {
        if (location.hash.split('access_token=')) {
            var accessToken = location.hash.split('access_token=')[1].split('&')[0];
            if (accessToken) {
                isUserRegistered(accessToken);
            }
        }
    }
}

function isUserRegistered(accessToken) {
    $.ajax({
        url: '/api/Account/UserInfo',
        method: 'GET',
        headers: {
            'content-type': 'application/json',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function (response) {
            if (response.HasRegistered) {
                localStorage.setItem("accessToken", accessToken);
                localStorage.setItem("userName", response.Email);
                window.location.href = "Data.html";
                alert("in")
            }
            else {
                // Pass the login provider (Facebook or Google)
                alert("sdf")
                signupExternalUser(accessToken, response.LoginProvider);
            }
        }
    });
}


// Include provider parameter
function signupExternalUser(accessToken, provider) {
    $.ajax({
        url: '/api/Account/RegisterExternal',
        method: 'POST',
        headers: {
            'content-type': 'application/json',
            'Authorization': 'Bearer ' + accessToken
        },
        success: function () {
            // Use the provider parameter value instead of
            // hardcoding the provider name
            window.location.href = "/api/Account/ExternalLogin?provider=Facebook&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A60629%2FLogin.html&state=NaPt-0OOxevMrUuhFH7YsVDwlX4zUZDDsh8ONo4nndk1";
        }
    });
}
