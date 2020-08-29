"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Shared_1 = require("../Shared");
var HomePage = /** @class */ (function () {
    function HomePage() {
    }
    HomePage.prototype.Init = function (labelId, buttonId) {
        this.label = document.getElementById(labelId);
        var button = document.getElementById(buttonId);
        button.addEventListener('click', this.onButtonClick.bind(this), false);
    };
    HomePage.prototype.onButtonClick = function (e) {
        var _this = this;
        var httpService = new Shared_1.SampleService();
        httpService.Post('/Home/GetMessage', {})
            .then(function (model) {
            _this.label.innerText = model.title;
        });
    };
    return HomePage;
}());
exports.HomePage = HomePage;
//# sourceMappingURL=Home.js.map