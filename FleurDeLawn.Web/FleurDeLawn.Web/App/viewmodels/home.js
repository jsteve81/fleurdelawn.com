define(['jquery', 'knockout', 'services/model'], function ($, ko, model) {

    var loginModel = {
        userName: ko.observable(""),
        password: ko.observable(""),
        stuff: ko.observableArray([])
    };

    var registerModel = {
        emailAddress: ko.observable(""),
        fullName: ko.observable(""),
        password: ko.observable(""),
        confirmPassword: ko.observable(""),
        valdatePasswordMatch: function() {
            return password == confirmPassword;
        }
    };

    var vm = {
        activate: activate,
        loginModel: loginModel,
        registerModel: registerModel,
        title: 'Welcome Home To The Man Page!',
        toggleRegistrationSignup: toggleRegistrationSignup,
        scrollTo: scrollTo
};
    return vm;

    function activate() {
        model.clean(loginModel);
        model.clean(registerModel);
    }

    function toggleRegistrationSignup(item, event) {
        var target = $(event.target).attr('id');
        var login = $('#loginbox');
        var signup = $('#signupbox');
        if (target == 'aShowSignup') {
            login.fadeOut(function() {
                signup.fadeIn();
            });
        } else {
            signup.fadeOut(function() {
                login.fadeIn();
            });
        }
    }



    function scrollTo(item, event) {
        var target = $(event.target).attr('data-scrollto');
        var scrollToItem = $(target);
        var scrollPosition = scrollToItem.offset().top - 60;
        if (scrollToItem.attr('id')) {
            $('html,body').animate({
                scrollTop: scrollPosition
            }, 1000);
            return false;
        }
        return false;
    }


});