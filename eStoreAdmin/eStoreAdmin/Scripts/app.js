var ViewModel = function () {
    var self = this;
    self.patterns = ko.observableArray();
    self.error = ko.observable();
    self.details = ko.observable();

    //************  Remember to change the URI accordingly  **********************//
    var patternsURI = 'http://localhost:61332/api/Patterns/';//change to your api

    //** this section contains all the AJAX call to the Web APIs **//
    // function to retrieve all products using AJAX call to web API
    function getAllPatterns() {
        $.ajax({
            type: 'GET',
            url: patternsURI,
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                self.patterns(data);
            },
            error: function (err) {
                alert("Error: " + err.status + " " + err.statusText);
            }
        });
    };
    // end of function to retrieve all products    
    self.getPatternDetails = function (item) {
        $.ajax({
            type: 'GET',
            url: patternsURI + item.Id,
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                self.details(data);
            },
            error: function (err) {
                alert("Error: " + err.status + " " + err.statusText);
            }
        });
    }

    self.newPattern = {
        Id: ko.observable(),
        Date: ko.observable(),
        Temperature: ko.observable(),
        Humidity: ko.observable(),
        RealPower: ko.observable(),
        ActivePower: ko.observable(),

    };



    // start of the function to save the new product record to database via Web API
    self.addPattern = function () {
        var aPattern = {
            Id: self.newPattern.Id(), // auto number field
            Date: self.newPattern.Date(),
            Temperature: self.newPattern.Temperature(),
            Humidity: self.newPattern.Humidity(),
            RealPower: self.newPattern.RealPower(),
            ActivePower: self.newPattern.ActivePower(),
        };

        $.ajax({
            type: 'POST',
            url: patternsURI,
            data: JSON.stringify(aPattern),
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                self.patterns.push(data);
                alert("Record created successfully!");
            },
            error: function (err) {
                alert("Error: " + err.status + " " + err.statusText);
            }
        });
    };
    // end of the function to save the new product record to database


    // end of function to update information of a product  
    // end of the function to save the new product record to database

    // method to save the updated product details

    var updatePattern = {
        Id: self.details.Id,
        Date: self.details.Date,
        Temperature: self.details.Temperature,
        Humidity: self.details.Humidity,
        RealPower: self.details.RealPower,
        ActivePower: self.details.ActivePower,
    };

    $.ajax({
        type: 'PUT',
        url: patternsURI + updatePattern.Id,
        data: JSON.stringify(updatePattern),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            self.patterns.replace(data);
            alert("Record updated successfully!");
        },
        error: function (err) {
            alert("Error: " + err.status + " " + err.statusText);
        }
    });

    // end of method to save the updated product details

    // remove record from database using web api
    self.removePattern = function () {
        var thePattern = {
            Id: self.details().Id,
            Date: self.details().Date,
            Temperature: self.details().Temperature,
            Humidity: self.details().Humidity,
            ActivePower: self.details().ActivePower,
            RealPower: self.details().RealPower,

        };

        if (confirm('Are you sure to delete "' + thePattern.Id + '"?')) {
            $.ajax({
                type: 'DELETE',
                url: patternsURI + thePattern.Id,
                dataType: 'json',
                contentType: 'application/json',
                success: function (data) {
                    self.patterns.remove(thePattern);
                    alert("Record has been deleted!");
                },
                error: function (err) {
                    alert("Error: " + err.status + " " + err.statusText);
                }
            });
        };
    }
    // end of method to remove the selected product




    //** this is the end of the section contains all the AJAX call to the Web APIs **//

    // Fetch the initial data
    getAllPatterns();
};


ko.applyBindings(new ViewModel());
