"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var leaflet_1 = require("leaflet");
var HomeComponent = /** @class */ (function () {
    function HomeComponent() {
        this.optionsSpec = {
            layers: [{ url: 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', attribution: 'Open Street Map' }],
            zoom: 5,
            center: [46.879966, -121.726909]
        };
        // Leaflet bindings
        this.zoom = this.optionsSpec.zoom;
        this.center = leaflet_1.latLng(this.optionsSpec.center);
        this.options = {
            layers: [leaflet_1.tileLayer(this.optionsSpec.layers[0].url, { attribution: this.optionsSpec.layers[0].attribution })],
            zoom: this.optionsSpec.zoom,
            center: leaflet_1.latLng(this.optionsSpec.center)
        };
        // Form bindings
        this.formZoom = this.zoom;
        this.zoomLevels = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14];
        this.lat = this.center.lat;
        this.lng = this.center.lng;
    }
    // Output binding for center
    HomeComponent.prototype.onCenterChange = function (center) {
        var _this = this;
        setTimeout(function () {
            _this.lat = center.lat;
            _this.lng = center.lng;
        });
    };
    HomeComponent.prototype.onZoomChange = function (zoom) {
        var _this = this;
        setTimeout(function () {
            _this.formZoom = zoom;
        });
    };
    HomeComponent.prototype.doApply = function () {
        this.center = leaflet_1.latLng(this.lat, this.lng);
        this.zoom = this.formZoom;
    };
    HomeComponent = __decorate([
        core_1.Component({
            selector: 'app-home',
            templateUrl: './home.component.html',
        })
    ], HomeComponent);
    return HomeComponent;
}());
exports.HomeComponent = HomeComponent;
//# sourceMappingURL=home.component.js.map