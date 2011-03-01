define(["application"], function (app) {
    return {
        sayHello: function (message) {
            alert("Hello" + message + app.appId);
        },
        init: function () {
            this.sayHello($('#message').data('message'));
        }
    };
}
);
