define(['knockout'], function(ko) {

    var clean = function(obj) {
        for (prop in obj) {
            if (ko.isObservable(obj[prop])) {
                if (typeof obj[prop].removeAll == 'undefined')
                    obj[prop]("");
                else
                    obj[prop]([]);
            }
        }
    };

    var mapToObservable = function(dto) {
        var mapped = {};
        for (prop in dto) {
            if (dto.hasOwnProperty(prop)) {
                mapped[prop] = ko.observable(dto[prop]);
            }
        }
        return mapped;
    };


    var model = {
        clean: clean,
        mapToObservalbe: mapToObservable
    };

    return model;

    

});